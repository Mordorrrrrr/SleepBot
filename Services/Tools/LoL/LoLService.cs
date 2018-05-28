#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT.Core;
using LoLMatchlist;
using LoLVerionsData;

#endregion

namespace DiscordBOT.Services.Tools
{
    public class LoLService
    {
        public static async Task SendLoLStatistics(string region, string summonername, ISocketMessageChannel channel)
        {
            var hch = new HttpClientHandler
            {
                Proxy = null,
                UseProxy = false
            };
            using (var http = new HttpClient(hch))
            {
                summonername = summonername.Replace(" ", "%20");
                region = region.ToLower();
                var regions = new[] {"ru", "kr", "br", "oc", "jp", "na", "eun", "euw", "tr", "la"};
                if (!regions.Contains(region, StringComparer.CurrentCultureIgnoreCase))
                {
                    await channel.SendMessageAsync("", false, EmbedService.ErrorBuilder("Region not found"));
                }
                else
                {
                    if (region != "ru" && region != "kr") region += "1";

                    try
                    {
                        var profileData = LoLProfile.LoLProfile.FromJson(await http.GetStringAsync(
                            $"https://{region}.api.riotgames.com/lol/summoner/v3/summoners/by-name/{summonername}?api_key={Variables.LoLAPiKey}"));
                        var matchList = LoLMatchlist.LoLMatchlist.FromJson(await http.GetStringAsync(
                            $"https://{region}.api.riotgames.com/lol/match/v3/matchlists/by-account/{profileData.AccountId}?endIndex=20&api_key={Variables.LoLAPiKey}"));

                        var rolelist = new List<string>();
                        var upper = matchList.Matches.Length > 20 ? 20 : matchList.Matches.Length;
                        var taskList = new List<Task<LoLResult>>();
                        for (var i = upper - 1; i >= 0; i--)
                            taskList.Add(new LoLService().GetLoLStatsAsync(region, matchList.Matches[i].GameId,
                                profileData.AccountId, matchList.Matches[i], i, http));

                        Task.WaitAll(taskList.ToArray());

                        rolelist.AddRange(taskList.Select(x => x.Result.role));
                        var kills = taskList.Sum(x => x.Result.kills);
                        var deaths = taskList.Sum(x => x.Result.deaths);
                        var wins = taskList.Sum(x => x.Result.win);
                        var minionKills = taskList.Sum(x => x.Result.minionKills);
                        var leaguearray = LoLLeague.LoLLeague.FromJson(await http.GetStringAsync(
                            $"https://{region}.api.riotgames.com/lol/league/v3/positions/by-summoner/{profileData.Id}?api_key={Variables.LoLAPiKey}"));
                        var league = leaguearray.Length > 0
                            ? leaguearray.Last()
                            : new LoLLeague.LoLLeague
                            {
                                FreshBlood = false,
                                HotStreak = false,
                                Inactive = true,
                                LeagueId = "",
                                LeagueName = "unranked",
                                LeaguePoints = 0,
                                Losses = 0,
                                PlayerOrTeamId = "",
                                PlayerOrTeamName = "",
                                QueueType = "None",
                                Tier = "Unranked",
                                Rank = "",
                                Veteran = false
                            };

                        var leaguepoints = league.LeaguePoints == 0 ? "" : league.LeaguePoints + "LP";

                        var latestVersion = LoLVersionsData.FromJson(
                            await http.GetStringAsync("https://ddragon.leagueoflegends.com/api/versions.json"))[0];
                        var icon = LoLProfilePictureData.LoLProfilePictureData
                            .FromJson(await http.GetStringAsync(
                                $"http://ddragon.leagueoflegends.com/cdn/{latestVersion}/data/en_US/profileicon.json"))
                            .Data.FirstOrDefault(x => x.Value.Id == profileData.ProfileIconId).Value.Image.Full;
                        var profileUrl =
                            $"http://ddragon.leagueoflegends.com/cdn/{latestVersion}/img/profileicon/{icon}";

                        var tierpng = league.Tier.ToLower() + (string.Equals(league.Tier, "Unranked",
                                          StringComparison.CurrentCultureIgnoreCase)
                                          ? ""
                                          : "_") + (string.Equals(league.Tier, "Unranked",
                                          StringComparison.CurrentCultureIgnoreCase)
                                          ? ""
                                          : RomanNumberService.RomanToInteger(league.Rank).ToString());
                        var eb = new EmbedBuilder();
                        eb.WithAuthor($"{profileData.Name} (level {profileData.SummonerLevel})", profileUrl)
                            .WithColor(Color.Blue)
                            .WithThumbnailUrl(
                                $"http://raw.communitydragon.org/latest/plugins/rcp-fe-lol-postgame/global/default/images/{tierpng}.png")
                            .WithFooter($"Stats from last {upper} matches",
                                "https://vignette.wikia.nocookie.net/leagueoflegends/images/1/12/League_of_Legends_Icon.png/revision/latest?cb=20150414082403&path-prefix=de")
                            .WithDescription(
                                $"Kills/Deaths: {kills}/{deaths} ({Math.Round(kills / (double) deaths, 4)})\nWins/Losses: {wins}/{upper - wins} ({Math.Round(wins / (upper - (double) wins), 4)})\nMinions killed: {minionKills}\nLeague: {league.Tier[0].ToString().ToUpper() + league.Tier.Substring(1).ToLower()} {league.Rank} {leaguepoints}\nRanked Wins/Losses: {league.Wins}/{league.Losses} ({Math.Round(league.Wins / (double) league.Losses, 4)})\nFavourite queue: {rolelist.Max()}");
                        await channel.SendMessageAsync("", false, eb.Build());
                    }
                    catch (Exception e)
                    {
                        await channel.SendMessageAsync("", false, EmbedService.ErrorBuilder("Couldn't get data"));
                    }
                }
            }
        }

        private async Task<LoLResult> GetLoLStatsAsync(string region, long matchid, long accountid, Match match,
            int index,
            HttpClient http)
        {
            var matchData = LoLMatch.LoLMatch.FromJson(await http.GetStringAsync(
                $"https://{region}.api.riotgames.com/lol/match/v3/matches/{matchid}?api_key={Variables.LoLAPiKey}"));
            var participantId = matchData.ParticipantIdentities
                .FirstOrDefault(x => x.Player.AccountId == accountid).ParticipantId;
            var data = matchData.Participants.FirstOrDefault(x => x.ParticipantId == participantId);
            var stats = data.Stats;

            var result = new LoLResult
            {
                kills = (int) stats.Kills,
                deaths = (int) stats.Deaths,
                win = stats.Win ? 1 : 0,
                minionKills = (int) stats.TotalMinionsKilled,
                role = match.Role.ToString()
            };
            return result;
        }

        private class LoLResult
        {
            public int deaths;
            public int kills;
            public int minionKills;
            public string role;
            public int win;
        }
    }
}
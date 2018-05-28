#region

using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT;
using DiscordBOT.Core;
using unirest_net.http;

#endregion

namespace SoccerData
{
    public class SoccerService
    {
        public static async Task SendGamesAsync(ISocketMessageChannel channel)
        {
            try
            {
                var games = await GetGamesAsync();
                var teams = await GetTeamsAsync();
                var upper = games.Length > 12 ? 12 : games.Length;
                var eb = new EmbedBuilder();
                eb.WithAuthor($"Last {upper} soccer games stats",
                        "https://upload.wikimedia.org/wikipedia/en/thumb/6/67/2018_FIFA_World_Cup.svg/1200px-2018_FIFA_World_Cup.svg.png")
                    .WithFooter("Stats from FIFA World Cup",
                        "https://upload.wikimedia.org/wikipedia/en/thumb/6/67/2018_FIFA_World_Cup.svg/1200px-2018_FIFA_World_Cup.svg.png")
                    .WithColor(Color.Blue);
                games = games.Reverse().ToArray();
                for (var i = 0; i < upper; i++)
                {
                    var date = games[i].PlayAt.Value;
                    eb.AddField($"{i + 1}. Game",
                        $"{teams.First(x => x.Id == games[i].Team1Id).Title} : {teams.First(x => x.Id == games[i].Team2Id).Title}\n{games[i].Score1 + games[i].Score1P + games[i].Score1Et.Value.Integer} : {games[i].Score2 + games[i].Score2P + games[i].Score2Et.Value.Integer}\nPlayed at: {await Util.GetDate(date.Date)}",
                        true);
                }

                await channel.SendMessageAsync("", false, eb.Build());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static async Task SendRoundsAsync(ISocketMessageChannel channel)
        {
            var data = await GetRoundsAsync();
            var upper = data.Length > 25 ? 25 : data.Length;
            var eb = new EmbedBuilder();
            eb.WithAuthor($"All {upper} round stats this cup",
                    "https://upload.wikimedia.org/wikipedia/en/thumb/6/67/2018_FIFA_World_Cup.svg/1200px-2018_FIFA_World_Cup.svg.png")
                .WithFooter("Stats from FIFA World Cup",
                    "https://upload.wikimedia.org/wikipedia/en/thumb/6/67/2018_FIFA_World_Cup.svg/1200px-2018_FIFA_World_Cup.svg.png")
                .WithColor(Color.Blue);

            foreach (var d in data)
            {
                var isInPast = DateTime.Now > d.StartAt;
                var startsorstarted = isInPast ? "Started" : "Starts";
                eb.AddField($"{d.Title}", $"{startsorstarted}: {await Util.GetDate(d.StartAt.Value.Date)}", true);
            }

            await channel.SendMessageAsync("", false, eb.Build());
        }

        public static async Task<TeamData.TeamData[]> GetTeamsAsync()
        {
            var response = Unirest.get("https://montanaflynn-fifa-world-cup.p.mashape.com/teams")
                .header("X-Mashape-Key", Variables.MarketplaceApiKey)
                .header("accepts", "json")
                .header("Accept", "application/json")
                .asString();
            var data = TeamData.TeamData.FromJson(response.Body);
            return data;
        }

        public static async Task<SoccerData[]> GetGamesAsync()
        {
            var response = Unirest.get("https://montanaflynn-fifa-world-cup.p.mashape.com/games")
                .header("X-Mashape-Key", Variables.MarketplaceApiKey)
                .header("accepts", "json")
                .header("Accept", "application/json")
                .asString();
            var data = SoccerData.FromJson(response.Body);
            return data;
        }

        public static async Task<RoundsData.RoundsData[]> GetRoundsAsync()
        {
            var response = Unirest.get("https://montanaflynn-fifa-world-cup.p.mashape.com/rounds")
                .header("X-Mashape-Key", "wOugjJt0gfmshviRsaEUaOKxDpcYp1MwN0Njsn0msrwjo9FJE2")
                .header("accepts", "json")
                .header("Accept", "application/json")
                .asString();
            var data = RoundsData.RoundsData.FromJson(response.Body);
            return data;
        }
    }
}
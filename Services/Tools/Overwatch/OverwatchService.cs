#region

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

#endregion

namespace DiscordBOT.Services.Tools.Overwatch
{
    public static class OverwatchService
    {
        public static async Task SendOverwatchStatsAsync(string platform, string region, string battletag,
            SocketGuildUser user, ISocketMessageChannel channel)
        {
            platform = platform.ToLower();
            region = region.ToLower();
            battletag = battletag.Replace("#", "-");
            var data = OverwatchData.OverwatchData.FromJson(
                await new HttpClient().GetStringAsync(
                    $"https://ow-api.com/v1/stats/{platform}/{region}/{battletag}/complete"));
            var eb = new EmbedBuilder();
            eb.WithAuthor($"{data.Name} (level {data.Level})",
                    data.Icon)
                .WithThumbnailUrl(data.RatingIcon)
                .WithColor(Color.Blue)
                .WithDescription(
                    $"Games won: {data.GamesWon}\nRank: {data.RatingName}\nRating: {data.Rating}")
                .AddField("Competitive stats",
                    $"Kills/Deaths: {data.CompetitiveStats.CareerStats.AllHeroes.Combat.Eliminations}/{data.CompetitiveStats.CareerStats.AllHeroes.Combat.Deaths} ({Math.Round(data.CompetitiveStats.CareerStats.AllHeroes.Combat.Eliminations / (double) data.CompetitiveStats.CareerStats.AllHeroes.Combat.Deaths, 4)})\nWins/Looses: {data.CompetitiveStats.CareerStats.AllHeroes.Game.GamesWon}/{data.CompetitiveStats.CareerStats.AllHeroes.Game.GamesLost} ({Math.Round(data.CompetitiveStats.CareerStats.AllHeroes.Combat.Eliminations / (double) data.CompetitiveStats.CareerStats.AllHeroes.Combat.Deaths, 4)}\nPlaytime: {data.CompetitiveStats.CareerStats.AllHeroes.Game.TimePlayed}\nMedals: {data.CompetitiveStats.Awards.MedalsBronze} Bronze, {data.CompetitiveStats.Awards.MedalsSilver} Silver, {data.CompetitiveStats.Awards.MedalsGold} Gold ({data.CompetitiveStats.Awards.Medals} in total)\nCards: {data.CompetitiveStats.Awards.Cards}")
                .AddField("Quickplay stats",
                    $"Kills/Deaths: {data.QuickPlayStats.CareerStats.AllHeroes.Combat.Eliminations}/{data.QuickPlayStats.CareerStats.AllHeroes.Combat.Deaths} ({Math.Round(data.QuickPlayStats.CareerStats.AllHeroes.Combat.Eliminations / (double) data.QuickPlayStats.CareerStats.AllHeroes.Combat.Deaths, 4)})\nWins: {data.QuickPlayStats.CareerStats.AllHeroes.Game.GamesWon}\nPlaytime: {data.QuickPlayStats.CareerStats.AllHeroes.Game.TimePlayed}\nMedals: {data.QuickPlayStats.Awards.MedalsBronze} Bronze, {data.QuickPlayStats.Awards.MedalsSilver} Silver, {data.QuickPlayStats.Awards.MedalsGold} Gold ({data.QuickPlayStats.Awards.Medals} in total)\nCards: {data.QuickPlayStats.Awards.Cards}");

            await channel.SendMessageAsync("", false, eb.Build());
        }
    }
}
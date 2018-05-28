#region

using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT.Core;
using unirest_net.http;

#endregion

namespace PingData
{
    public class PingService
    {
        public static async Task SendPingResult(string address, ISocketMessageChannel channel)
        {
            var result = await GetPingResult(address);
            var success = result.result ? "Yes" : "No";
            await channel.SendMessageAsync("", false,
                new EmbedBuilder().WithTitle("Ping result").WithDescription($"Success: {success}\nTime: {result.time}")
                    .WithColor(Color.Blue).Build());
        }

        public static async Task<PingResult> GetPingResult(string address)
        {
            var response = Unirest.get("https://igor-zachetly-ping-uin.p.mashape.com/pinguin.php?address=google.de")
                .header("X-Mashape-Key", Variables.MarketplaceApiKey)
                .header("Accept", "application/json")
                .asString();
            var data = PingData.FromJson(response.Body);
            var result = new PingResult(string.Equals(data.Result, "true", StringComparison.CurrentCultureIgnoreCase),
                data.Time);
            return result;
        }
    }

    public class PingResult
    {
        public bool result;
        public string time;

        public PingResult(bool result, string time)
        {
            this.result = result;
            this.time = time;
        }
    }
}
#region

using System.Threading.Tasks;
using Discord.WebSocket;
using unirest_net.http;

#endregion

namespace DiscordBot.Services.Tools
{
    public class QuoteService
    {
        public static async Task SendRandomQuoteAsync(string tag, ISocketMessageChannel channel)
        {
            var result = Unirest.get("https://andruxnet-random-famous-quotes.p.mashape.com/?cat=famous")
                .header("X-Mashape-Key", "wOugjJt0gfmshviRsaEUaOKxDpcYp1MwN0Njsn0msrwjo9FJE2")
                .header("Accept", "application/json")
                .asString();
            var data = QuoteData.QuoteData.FromJson(result.Body);
            await channel.SendMessageAsync($"{data[0].Quote} ~ {data[0].Author}");
        }
    }
}
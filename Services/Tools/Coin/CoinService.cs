#region

using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

#endregion

namespace DiscordBOT.Services.Tools
{
    public class CoinService
    {
        public static string[] SupportedCoins;

        public static async Task Initialize()
        {
            SupportedCoins = Coins.Coins.FromJson(await new HttpClient().GetStringAsync("http://coincap.io/coins/"));
        }

        public static async Task SendCoinStatsAsync(ISocketMessageChannel channel, string coin)
        {
            if (SupportedCoins == null) await Initialize();

            if (!SupportedCoins.Contains(coin, StringComparer.CurrentCultureIgnoreCase))
            {
                await channel.SendMessageAsync("", false,
                    EmbedService.ErrorBuilder($"The coin '{coin.ToUpper()}' wasn't found"));
            }
            else
            {
                var coinData =
                    CoinData.CoinData.FromJson(
                        await new HttpClient().GetStringAsync($"http://coincap.io/page/{coin.ToUpper()}"));
                var eb = new EmbedBuilder();
                eb.WithTitle($"{coinData.DisplayName} ({coinData.CoinDataId})")
                    .WithColor(Color.Blue)
                    .WithFooter("Statistics provided by coincap.io",
                        "https://www.android-user.de/wp-content/uploads/2017/05/unnamed.png")
                    .AddField("Price", coinData.Price + "$", true)
                    .AddField("Volume", coinData.VolumeBtc, true)
                    .AddField("Rank", coinData.Rank, true);
                await channel.SendMessageAsync("", false, eb.Build());
            }
        }
    }
}
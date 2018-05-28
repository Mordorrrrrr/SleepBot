#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;
using DiscordBOT.Services.Tools;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Price : ModuleBase<SocketCommandContext>
    {
        [Command("price")]
        [Alias("pr")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Shows the price of a coin")]
        public async Task EncodeAsync([Remainder] string coin = null)
        {
            if (coin == null)
            {
                if (CoinService.SupportedCoins == null) await CoinService.Initialize();
                await ReplyAsync("", false,
                    EmbedService.InfoBuilder("Coins",
                        $"There are {CoinService.SupportedCoins.Length} supported coins - get a full list on http://coincap.io/"));
            }
            else
            {
                await CoinService.SendCoinStatsAsync(Context.Guild.GetTextChannel(Context.Channel.Id), coin);
            }
        }
    }
}
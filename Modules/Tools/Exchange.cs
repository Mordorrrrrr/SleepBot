#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services.Tools.Exchange;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Exchange : ModuleBase<SocketCommandContext>
    {
        [Command("exchange")]
        [Alias("ex")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Exchanges two currencys")]
        public async Task ExchangeAsync(string fromcurrency = null, string tocurrency = null, long amount = 0)
        {
            if (fromcurrency == null && tocurrency == null && amount == 0)
                await ExchangeService.SendCurrencysAsync(Context.Guild.GetTextChannel(Context.Channel.Id));
            else
                await ExchangeService.SendExchangeAsync(fromcurrency, tocurrency, amount,
                    Context.Guild.GetTextChannel(Context.Channel.Id));
        }
    }
}
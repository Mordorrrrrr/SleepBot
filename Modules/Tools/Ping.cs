#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using PingData;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Pings an address")]
        public async Task ExchangeAsync([Remainder] string address)
        {
            await PingService.SendPingResult(address, Context.Channel);
        }
    }
}
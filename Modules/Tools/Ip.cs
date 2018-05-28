#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using IpData;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Ip : ModuleBase<SocketCommandContext>
    {
        [Command("ip")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Looks up for an IP")]
        public async Task ExchangeAsync([Remainder] string address)
        {
            await IpService.SendIpInformationAsync(address, Context.Guild.GetTextChannel(Context.Channel.Id));
        }
    }
}
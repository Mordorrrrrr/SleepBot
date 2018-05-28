#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using SoccerData;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class SoccerRounds : ModuleBase<SocketCommandContext>
    {
        [Command("soccerrounds")]
        [Alias("socrounds", "scrounds", "srounds", "socr", "scr", "sr")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Shows all soccer rounds from the FIFA World Cup")]
        public async Task RoundsAsync()
        {
            await SoccerService.SendRoundsAsync(Context.Channel);
        }
    }
}
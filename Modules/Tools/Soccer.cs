#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using SoccerData;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Soccer : ModuleBase<SocketCommandContext>
    {
        [Command("soccer")]
        [Alias("soc", "sc")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Shows the stats of the last 12 soccer games")]
        public async Task GamesAsync()
        {
            await SoccerService.SendGamesAsync(Context.Channel);
        }
    }
}
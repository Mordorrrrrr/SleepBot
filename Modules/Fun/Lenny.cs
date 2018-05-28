#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Lenny : ModuleBase<SocketCommandContext>
    {
        [Command("lenny", RunMode = RunMode.Async)]
        [Alias("lenn", "l")]
        [CommandCategory(Category = CommandCategory.Fun)]
        [Summary("Sends a lenny face")]
        public async Task LennyAsync()
        {
            await ReplyAsync("( ͡° ͜ʖ ͡°)");
        }
    }
}
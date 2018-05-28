#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Nut : ModuleBase<SocketCommandContext>
    {
        [Command("nut")]
        [CommandCategory(Category = CommandCategory.Fun)]
        [Summary("█▀█ █▄█ ▀█▀ the chat")]
        public async Task NutAsync()
        {
            await ReplyAsync("I AM A REAL █▀█ █▄█ ▀█▀");
        }
    }
}
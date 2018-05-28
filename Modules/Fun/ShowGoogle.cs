#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class ShowGoogle : ModuleBase<SocketCommandContext>
    {
        [Command("showgoogle", RunMode = RunMode.Async)]
        [CommandCategory(Category = CommandCategory.Fun)]
        [Alias("sg", "showg", "sgoogle")]
        [Summary("Shows someone how to google")]
        public async Task GoogleAsync([Remainder] string search)
        {
            search = search.Replace(" ", "+");
            await ReplyAsync($"http://lmgtfy.com/?q={search}");
        }
    }
}
#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Google : ModuleBase<SocketCommandContext>
    {
        [Command("google", RunMode = RunMode.Async)]
        [CommandCategory(Category = CommandCategory.Fun)]
        [Alias("g")]
        [Summary("Shows someone how to google")]
        public async Task GoogleAsync([Remainder] string search)
        {
            search = search.Replace(" ", "+");
            await ReplyAsync($"https://www.google.com/search?q={search}");
        }
    }
}
#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services.Tools.Search;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Search : ModuleBase<SocketCommandContext>
    {
        [Command("search")]
        [Alias("sr", "srch")]
        [Summary("Searches something from the internet")]
        [CommandCategory(Category = CommandCategory.Tools)]
        public async Task SearchAsync([Remainder] string query)
        {
            await SearchService.SendSearchResultAsync(query, Context.Guild.GetTextChannel(Context.Channel.Id));
        }
    }
}
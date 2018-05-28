#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBot.Services.Tools;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Urban : ModuleBase<SocketCommandContext>
    {
        [Command("urban")]
        [Alias("u", "ur", "urb")]
        [Summary("Searches a word in the urban dictionary")]
        [CommandCategory(Category = CommandCategory.Tools)]
        public async Task UrbanAsync([Remainder] string term)
        {
            await UrbanService.SendDictionaryResult(term, Context.Guild.GetTextChannel(Context.Channel.Id));
        }
    }
}
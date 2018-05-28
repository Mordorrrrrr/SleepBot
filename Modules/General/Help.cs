#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;

#endregion

namespace DiscordBOT.Modules.General
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("help", RunMode = RunMode.Async)]
        [Alias("h", "he")]
        [CommandCategory(Category = CommandCategory.General)]
        [Summary("Shows a list of commands")]
        public async Task HelpAsync([Remainder] string command = null)
        {
            if (command == null)
                await new HelpService().HelpListAsync(Context.Channel, Context.Guild);
            else
                await new HelpService().HelpCommandAsync(Context.Channel, command);
        }
    }
}
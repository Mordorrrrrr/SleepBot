#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;

#endregion

namespace DiscordBOT.Modules.General
{
    public class Afk : ModuleBase<SocketCommandContext>
    {
        [Command("afk", RunMode = RunMode.Async)]
        [Alias("a", "awayfromkeyboard")]
        [CommandCategory(Category = CommandCategory.General)]
        [Summary("Sets your afk status")]
        public async Task HelpAsync()
        {
            if (Context.Guild.GetUser(Context.Client.CurrentUser.Id).Hierarchy <=
                Context.Guild.GetUser(Context.User.Id).Hierarchy)
                await ReplyAsync("", false,
                    EmbedService.ErrorBuilder(
                        $"{Program.Client.CurrentUser.Username} has not enough permissions to do this"));
            else
                await AfkService.SetAfkAsync(Context.Guild.GetUser(Context.User.Id), Context.Channel);
        }
    }
}
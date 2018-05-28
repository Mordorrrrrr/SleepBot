#region

using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services;

#endregion

namespace DiscordBOT.Modules.Moderation
{
    public class Clear : ModuleBase<SocketCommandContext>
    {
        [Command("clear", RunMode = RunMode.Async)]
        [Alias("c", "cl")]
        [CommandCategory(Category = CommandCategory.Moderation)]
        [Summary("Clears the chat")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task ClearAsync(int count, SocketGuildUser user = null)
        {
            if (count < 1 || count > 1000)
                await ReplyAsync("", false,
                    EmbedService.ErrorBuilder("Cannot delete less than 1 or more than 1000 messages"));
            else if (user == null)
                await ClearService.ClearAsync(Context.Guild.GetTextChannel(Context.Channel.Id), count, Context.Guild,
                    Context.Guild.GetUser(Context.User.Id));
            else
                await ClearService.ClearFromUserAsync(Context.Guild.GetTextChannel(Context.Channel.Id), Context.Guild,
                    Context.Guild.GetUser(user.Id), count, Context.Guild.GetUser(Context.User.Id));
        }
    }
}
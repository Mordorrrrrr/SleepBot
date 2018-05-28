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
    public class Nick : ModuleBase<SocketCommandContext>
    {
        [Command("nick")]
        [Alias("n", "nickname", "changenick")]
        [CommandCategory(Category = CommandCategory.Moderation)]
        [Summary("Changes a user's nickname")]
        [RequireUserPermission(GuildPermission.ManageNicknames)]
        [RequireBotPermission(GuildPermission.ManageNicknames)]
        public async Task NickAsync(SocketGuildUser user, [Remainder] string nickname)
        {
            if (Context.Guild.GetUser(Context.User.Id).Hierarchy <= user.Hierarchy)
                await ReplyAsync("", false, EmbedService.ErrorBuilder("You have not enough permissions to do this"));
            else if (Context.Guild.GetUser(Program.Client.CurrentUser.Id).Hierarchy <= user.Hierarchy)
                await ReplyAsync("", false,
                    EmbedService.ErrorBuilder(
                        $"{Program.Client.CurrentUser.Username} has not enough permissions to do this"));
            else
                await NickService.NickUserAsync(Context.Guild.GetTextChannel(Context.Channel.Id), user, nickname);
        }
    }
}
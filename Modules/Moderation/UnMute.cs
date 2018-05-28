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
    public class UnMute : ModuleBase<SocketCommandContext>
    {
        [Command("unmute")]
        [Alias("um")]
        [CommandCategory(Category = CommandCategory.Moderation)]
        [Summary("Unmutes a member")]
        [RequireUserPermission(GuildPermission.MuteMembers)]
        [RequireBotPermission(GuildPermission.MuteMembers)]
        public async Task NickAsync(SocketGuildUser user)
        {
            if (Context.Guild.GetUser(Context.User.Id).Hierarchy <= user.Hierarchy)
                await ReplyAsync("", false, EmbedService.ErrorBuilder("You have not enough permissions to do this"));
            else if (Context.Guild.GetUser(Program.Client.CurrentUser.Id).Hierarchy <= user.Hierarchy)
                await ReplyAsync("", false,
                    EmbedService.ErrorBuilder(
                        $"{Program.Client.CurrentUser.Username} has not enough permissions to do this"));
            else
                await MuteService.UnmuteAsync(user, Context.Guild, Context.Channel,
                    Context.Guild.GetUser(Context.User.Id));
        }
    }
}
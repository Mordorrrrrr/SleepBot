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
    public class Mute : ModuleBase<SocketCommandContext>
    {
        [Command("mute")]
        [Alias("m")]
        [CommandCategory(Category = CommandCategory.Moderation)]
        [Summary("Mutes a member")]
        [RequireUserPermission(GuildPermission.MuteMembers)]
        [RequireBotPermission(GuildPermission.MuteMembers)]
        public async Task NickAsync(SocketGuildUser user, [Remainder] string reason = "no reason")
        {
            if (Context.Guild.GetUser(Context.User.Id).Hierarchy <= user.Hierarchy)
                await ReplyAsync("", false, EmbedService.ErrorBuilder("You have not enough permissions to do this"));
            else if (Context.Guild.GetUser(Program.Client.CurrentUser.Id).Hierarchy <= user.Hierarchy)
                await ReplyAsync("", false,
                    EmbedService.ErrorBuilder(
                        $"{Program.Client.CurrentUser.Username} has not enough permissions to do this"));
            else
                await MuteService.MuteAsync(user, Context.Guild, Context.Channel, reason,
                    Context.Guild.GetUser(Context.User.Id));
        }
    }
}
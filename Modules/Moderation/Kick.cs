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
    public class Kick : ModuleBase<SocketCommandContext>
    {
        [Command("kick")]
        [Alias("k", "ki")]
        [CommandCategory(Category = CommandCategory.Moderation)]
        [Summary("Kicks a user")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        [RequireBotPermission(GuildPermission.KickMembers)]
        public async Task BanAsync(SocketGuildUser user, string reason = "no reason")
        {
            if (Context.Guild.GetUser(Context.User.Id).Hierarchy <= user.Hierarchy)
                await ReplyAsync("", false, EmbedService.ErrorBuilder("You have not enough permissions to do this"));
            else if (Context.Guild.GetUser(Program.Client.CurrentUser.Id).Hierarchy <= user.Hierarchy)
                await ReplyAsync("", false,
                    EmbedService.ErrorBuilder(
                        $"{Program.Client.CurrentUser.Username} has not enough permissions to do this"));
            else
                await KickService.KickUserAsync(user, Context.User as SocketGuildUser, Context.Guild,
                    Context.Guild.GetTextChannel(Context.Channel.Id), reason);
        }
    }
}
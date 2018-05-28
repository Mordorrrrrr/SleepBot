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
    public class Ban : ModuleBase<SocketCommandContext>
    {
        [Command("ban")]
        [Alias("b", "ba")]
        [CommandCategory(Category = CommandCategory.Moderation)]
        [Summary("Bans a user")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task BanAsync(SocketGuildUser user, string reason = null)
        {
            if (Context.Guild.GetUser(Context.User.Id).Hierarchy <= user.Hierarchy)
                await ReplyAsync("", false, EmbedService.ErrorBuilder("You have not enough permissions to do this"));
            else if (Context.Guild.GetUser(Program.Client.CurrentUser.Id).Hierarchy <= user.Hierarchy)
                await ReplyAsync("", false,
                    EmbedService.ErrorBuilder(
                        $"{Program.Client.CurrentUser.Username} has not enough permissions to do this"));
            else
                await BanService.BanUserAsync(user, Context.User as SocketGuildUser, Context.Guild,
                    Context.Channel, reason);
        }
    }
}
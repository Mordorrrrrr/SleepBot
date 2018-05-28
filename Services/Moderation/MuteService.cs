#region

using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Modules.Administration;

#endregion

namespace DiscordBOT.Services
{
    public class MuteService
    {
        public static async Task MuteAsync(SocketGuildUser user, SocketGuild guild, IMessageChannel channel,
            string reason, SocketGuildUser userwhomuted)
        {
            if (guild.Roles.All(x => x.Name != $"{Program.Client.CurrentUser.Username}-Muted"))
                await guild.CreateRoleAsync($"{Program.Client.CurrentUser.Username}-Muted", new GuildPermissions(),
                    Color.LightGrey);
            var specificRole =
                guild.Roles.First(y => y.Name == $"{Program.Client.CurrentUser.Username}-Muted");

            foreach (var c in guild.Channels)
            {
                if (c.PermissionOverwrites.Any(x =>
                    x.TargetType == PermissionTarget.Role && x.TargetId == specificRole.Id && x.Permissions.Equals(new OverwritePermissions(PermValue.Deny, addReactions: PermValue.Deny))))
                    continue;

                await c.AddPermissionOverwriteAsync(
                    guild.Roles.FirstOrDefault(x => x.Name == $"{Program.Client.CurrentUser.Username}-Muted"),
                    new OverwritePermissions(PermValue.Deny, addReactions: PermValue.Deny));
            }

            if (user.Roles.Contains(specificRole))
            {
                await channel.SendMessageAsync("", false,
                    EmbedService.ErrorBuilder($"{user.Mention} is already muted"));
                return;
            }

            await user.AddRoleAsync(specificRole);

            await channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully muted {user.Mention} for {reason}"));
            await user.SendMessageAsync("", false,
                EmbedService.ErrorBuilder(
                    $"You have been muted by {userwhomuted.Nickname ?? userwhomuted.Username} for {reason}"));
            await LogService.SendLogMessageAsync(guild, "", false,
                EmbedService.LogBuilder("User muted", $"{userwhomuted.Mention} muted {user.Mention} for {reason}"));
        }

        public static async Task UnmuteAsync(SocketGuildUser user, SocketGuild guild, IMessageChannel channel,
            SocketGuildUser userwhomuted)
        {
            if (guild.Roles.All(x => x.Name != $"{Program.Client.CurrentUser.Username}-Muted"))
                await guild.CreateRoleAsync($"{Program.Client.CurrentUser.Username}-Muted", new GuildPermissions(),
                    Color.LightGrey);
            var specificRole =
                guild.Roles.First(y => y.Name == $"{Program.Client.CurrentUser.Username}-Muted");
            if (!user.Roles.Contains(specificRole))
            {
                await channel.SendMessageAsync("", false, EmbedService.ErrorBuilder($"{user.Mention} isn't muted"));
                return;
            }

            await user.RemoveRoleAsync(specificRole);
            await channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully unmuted {user.Mention}"));
            await user.SendMessageAsync("", false,
                EmbedService.ErrorBuilder(
                    $"You have been unmuted by {userwhomuted.Nickname ?? userwhomuted.Username}"));
            await LogService.SendLogMessageAsync(guild, "", false,
                EmbedService.LogBuilder("User unmuted", $"{userwhomuted.Mention} unmuted {user.Mention}"));
        }

        public static async Task AddPermissionOverwriteAsync(SocketChannel channel)
        {
            var guildchannel = channel as SocketGuildChannel;
            var specificRole =
                guildchannel.Guild.Roles.First(y => y.Name == $"{Program.Client.CurrentUser.Username}-Muted");
            await guildchannel.AddPermissionOverwriteAsync(specificRole,
                new OverwritePermissions(PermValue.Deny));
        }
    }
}
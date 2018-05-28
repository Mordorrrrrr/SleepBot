#region

using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT.Modules.Administration;

#endregion

namespace DiscordBOT.Services
{
    public class BanService
    {
        public static async Task BanUserAsync(SocketGuildUser usertoban, SocketGuildUser user, SocketGuild guild,
            ISocketMessageChannel
                channel, string reason)
        {
            if (usertoban.IsBot)
            {
                await channel.SendMessageAsync("", false, EmbedService.ErrorBuilder("Cannot ban bots"));
                return;
            }

            await usertoban.SendMessageAsync("", false,
                EmbedService.ErrorBuilder($"You have been banned from {guild.Name} by {user.Mention} for {reason}"));
            await LogService.SendLogMessageAsync(guild, "", false,
                EmbedService.LogBuilder("User banned",
                    $"{user.Mention} banned {usertoban.Nickname ?? usertoban.Username} for {reason}"));
            await guild.AddBanAsync(usertoban, 0, reason);
            await channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully banned {usertoban.Mention} for {reason}"));
        }
    }
}
#region

using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT.Modules.Administration;

#endregion

namespace DiscordBOT.Services
{
    public static class KickService
    {
        public static async Task KickUserAsync(SocketGuildUser usertokick, SocketGuildUser user, SocketGuild guild,
            SocketTextChannel channel, string reason)
        {
            if (usertokick.IsBot)
            {
                await channel.SendMessageAsync("", false, EmbedService.ErrorBuilder("Cannot kick bots"));
                return;
            }

            await usertokick.SendMessageAsync("", false,
                EmbedService.ErrorBuilder($"You have been kicked from {guild.Name} by {user.Mention} for {reason}"));
            await LogService.SendLogMessageAsync(guild, "", false,
                EmbedService.LogBuilder("User kicked",
                    $"{user.Mention} kicked {usertokick.Nickname ?? usertokick.Username} for {reason}"));
            await usertokick.KickAsync(reason);
            await channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully kicked {usertokick.Mention} for {reason}"));
        }
    }
}
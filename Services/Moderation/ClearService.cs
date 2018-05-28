#region

using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT.Modules.Administration;

#endregion

namespace DiscordBOT.Services
{
    public static class ClearService
    {
        public static async Task ClearAsync(SocketTextChannel channel, int count, SocketGuild server,
            SocketGuildUser user)
        {
            var messages = await channel.GetMessagesAsync(count + 1).FlattenAsync();
            messages = messages.Where(x => x.Timestamp.DateTime >= DateTime.Now - TimeSpan.FromDays(14));
            await channel.DeleteMessagesAsync(messages);
            var messagecount = messages.Count() - 1 == 1 ? "message" : "messages";
            var message = await channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully deleted {messages.Count() - 1} {messagecount}"));
            await LogService.SendLogMessageAsync(server, "", false,
                EmbedService.LogBuilder("Chat cleared",
                    $"{user.Mention} cleared {messages.Count() - 1} {messagecount} messages in {channel.Mention}"));
            await Task.Delay(TimeSpan.FromSeconds(15));
            await message.DeleteAsync();
        }

        public static async Task ClearFromUserAsync(SocketTextChannel channel, SocketGuild server, SocketGuildUser user,
            int count, SocketGuildUser actionUser)
        {
            var deleted = 0;
            foreach (var c in server.TextChannels)
            {
                var messages = await c.GetMessagesAsync().FlattenAsync();
                messages = messages.Where(x => x.Author == user).Take(count)
                    .Where(x => x.Timestamp.DateTime >= DateTime.Now - TimeSpan.FromDays(14));
                await c.DeleteMessagesAsync(messages);
                deleted += messages.Count();
            }

            var messagecount = deleted - 1 == 1 ? "message" : "messages";
            var message = await channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully deleted {deleted} {messagecount}"));
            await LogService.SendLogMessageAsync(server, "", false,
                EmbedService.LogBuilder("Chat cleared",
                    $"{actionUser.Mention} cleared {messagecount} {deleted} in {channel.Mention} from {user.Mention}"));
            await Task.Delay(TimeSpan.FromSeconds(15));
            await message.DeleteAsync();
        }
    }
}
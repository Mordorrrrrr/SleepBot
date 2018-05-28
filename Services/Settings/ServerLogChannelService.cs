#region

using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

#endregion

namespace DiscordBOT.Services.Administration
{
    public class ServerLogChannelService
    {
        public static async Task SetLogChannel(SocketGuild guild, SocketGuildChannel channel,
            SocketTextChannel chat)
        {
            DatabaseService.SetLogChannelId(guild.Id, channel.Id);

            chat.SendMessageAsync("", false,
                EmbedService.SuccesBuilder(
                    $"Successfully set the server's logchannel to {(channel as ITextChannel).Mention}"));
        }

        public static async Task<ulong> GetLogChannelId(SocketGuild guild)
        {
            return await DatabaseService.GetLogChannelId(guild.Id);
        }
    }
}
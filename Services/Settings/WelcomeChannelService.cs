#region

using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

#endregion

namespace DiscordBOT.Services.Administration
{
    public class WelcomeChannelService
    {
        public static async Task SetWelcomeChannel(SocketGuild guild, SocketGuildChannel channel,
            SocketTextChannel chat)
        {
            DatabaseService.SetWelcomeChannelId(guild.Id, channel.Id);

            chat.SendMessageAsync("", false,
                EmbedService.SuccesBuilder(
                    $"Successfully set the server's welcomechannel to {(channel as ITextChannel).Mention}"));
        }

        public static async Task<ulong> GetWelcomeChannelId(SocketGuild guild)
        {
            return await DatabaseService.GetWelcomeChannelId(guild.Id);
        }
    }
}
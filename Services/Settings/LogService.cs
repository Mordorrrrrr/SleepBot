#region

using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT.Services.Administration;

#endregion

namespace DiscordBOT.Modules.Administration
{
    public class LogService
    {
        public static async Task SendLogMessageAsync(SocketGuild guild, string message, bool isTts, Embed embed)
        {
            var channel = guild.GetTextChannel(await ServerLogChannelService.GetLogChannelId(guild));
            await channel.SendMessageAsync(message, isTts, embed);
        }
    }
}
#region

using System.Threading.Tasks;
using Discord.WebSocket;

#endregion

namespace DiscordBOT.Services.Administration
{
    public static class ServerAnnounceService
    {
        public static async Task SetWelcomeMessage(SocketGuild guild, string message, SocketTextChannel channel)
        {
            DatabaseService.SetWelcomeMessage(guild.Id, message);

            var msg = message == "" ? "the default one" : "'" + message + "'";
            channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully set the server's welcomemessage to {msg}"));
        }

        public static async Task<string> GetWelcomeMessage(SocketGuild guild)
        {
            return await DatabaseService.GetWelcomeMessage(guild.Id);
        }

        public static async Task SetLeaveMessage(SocketGuild guild, string message, SocketTextChannel channel)
        {
            DatabaseService.SetLeaveMessage(guild.Id, message);

            var msg = message == "" ? "the default one" : "'" + message + "'";
            channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully set the server's leavemessage to {msg}"));
        }

        public static async Task<string> GetLeaveMessage(SocketGuild guild)
        {
            return await DatabaseService.GetLeaveMessage(guild.Id);
        }
    }
}
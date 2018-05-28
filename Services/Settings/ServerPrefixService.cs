#region

using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Services.Administration
{
    public static class ServerPrefixService
    {
        public static async Task SetServerPrefix(SocketGuild guild, string prefix, SocketTextChannel channel)
        {
            DatabaseService.SetServerPrefix(guild.Id, prefix == Variables.BotPrefix ? "" : prefix);

            await channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully set the server prefix to {prefix}"));
        }

        public static async Task<string> GetServerPrefix(SocketGuild guild)
        {
            return await DatabaseService.GetServerPrefix(guild.Id);
        }
    }
}
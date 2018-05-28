using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBOT.Services;
using DiscordBOT.Services.Administration;

namespace DiscordBot.Services.Settings
{
    public class EveryoneRoleService
    {
        public static async Task SetEveryoneRoleAsync(SocketGuild guild, SocketRole role, ISocketMessageChannel channel)
        {
            DatabaseService.SetEveryoneRoleID(guild.Id, role.Id);

            await channel.SendMessageAsync("", false, EmbedService.SuccesBuilder($"Successfully set the everyonerole to {role.Name}"));
        }

        public static async Task<ulong> GetEveryoneRoleAsync(SocketGuild guild)
        {
            return await DatabaseService.GetEveryoneRoleID(guild.Id);
        }
    }
}
#region

using System.Threading.Tasks;
using Discord.WebSocket;

#endregion

namespace DiscordBOT.Services
{
    public class AfkService
    {
        public static async Task SetAfkAsync(SocketGuildUser user, ISocketMessageChannel channel)
        {
            var oldusernick = user.Nickname ?? user.Username;
            await user.ModifyAsync(x => x.Nickname = "[AFK] " + oldusernick);
            await channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder("Successfully set your status to AFK"));
        }

        public static async Task CheckAfkAsync(SocketGuildUser user, ISocketMessageChannel channel)
        {
            if (user.Nickname.Contains("[AFK]")) await user.ModifyAsync(x => x.Nickname = user.Nickname.Remove(0, 5));
        }
    }
}
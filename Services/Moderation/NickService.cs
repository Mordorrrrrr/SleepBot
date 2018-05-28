#region

using System.Threading.Tasks;
using Discord.WebSocket;

#endregion

namespace DiscordBOT.Services
{
    public class NickService
    {
        public static async Task NickUserAsync(SocketTextChannel channel, SocketGuildUser user, string nickname)
        {
            if (nickname.Length >= 32)
            {
                await channel.SendMessageAsync("", false,
                    EmbedService.ErrorBuilder("The nickname is longer than 32 letter"));
            }
            else
            {
                var oldnickname = user.Nickname ?? user.Username;
                user.ModifyAsync(x => x.Nickname = nickname);
                channel.SendMessageAsync("", false,
                    EmbedService.SuccesBuilder(
                        $"Successfully changed {oldnickname}'s name to {nickname}"));
            }
        }
    }
}
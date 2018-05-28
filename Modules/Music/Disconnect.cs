#region

using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services.Music;

#endregion

namespace DiscordBOT.Modules.Music
{
    public class Disconnect : ModuleBase<SocketCommandContext>
    {
        [Command("disconnect")]
        [Alias("leave", "l", "dis", "disc")]
        [CommandCategory(Category = CommandCategory.Music)]
        [Summary("Lets the bot disconnect from your channel")]
        public async Task DisconnectAsync()
        {
            await MusicService.DisconnectAsync(Context.Guild, Context.Channel as SocketTextChannel,
                Context.Guild.GetUser(Context.User.Id).VoiceChannel, Context.Guild.GetUser(Context.User.Id));
        }
    }
}
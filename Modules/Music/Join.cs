#region

using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services.Music;

#endregion

namespace DiscordBOT.Modules.Music
{
    public class Join : ModuleBase<SocketCommandContext>
    {
        [Command("join", RunMode = RunMode.Async)]
        [CommandCategory(Category = CommandCategory.Music)]
        [Alias("j")]
        [Summary("Lets the bot join your channel")]
        public async Task JoinAsync()
        {
            await MusicService.JoinAsync(Context.Channel as SocketTextChannel,
                Context.Guild.GetUser(Context.User.Id));
        }
    }
}
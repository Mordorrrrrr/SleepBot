#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services.Music;

#endregion

namespace DiscordBOT.Modules.Music
{
    public class Play : ModuleBase<SocketCommandContext>
    {
        [Command("play")]
        [CommandCategory(Category = CommandCategory.Music)]
        [Alias("p")]
        [Summary("Lets the bot play music")]
        public async Task PlayAsync(string youttubeurl)
        {
            await MusicService.PlayAsync(Context, youttubeurl);
        }
    }
}
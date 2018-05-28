using System.IO;
using System.Net;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBOT.Modules.Moderation
{
    public class MyCommand : ModuleBase<SocketCommandContext>
    {
        [Command("mycommand")]
        public async Task MyCommandAsync()
        {
            await ReplyAsync(File.ReadAllText(@"My file path"));
        }
    }
}
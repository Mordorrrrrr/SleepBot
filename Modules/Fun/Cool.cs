#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Cool : ModuleBase<SocketCommandContext>
    {
        [Command("cool", RunMode = RunMode.Async)]
        [CommandCategory(Category = CommandCategory.Fun)]
        [Summary("Sends something cool in the chat")]
        public async Task CoolAsync()
        {
            var msg = await ReplyAsync("( ͡° ͜ʖ ͡°)>⌐■-■");
            await Task.Delay(1500);
            await msg.ModifyAsync(x => { x.Content = "( ͡⌐■ ͜ʖ ͡-■)"; });
        }
    }
}
#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Say : ModuleBase<SocketCommandContext>
    {
        [Command("say", RunMode = RunMode.Async)]
        [Alias("s")]
        [Summary("Lets the bot say something")]
        [CommandCategory(Category = CommandCategory.Fun)]
        public async Task SayAsync([Remainder] string message)
        {
            await ReplyAsync(message);
        }
    }
}
#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("ping", RunMode = RunMode.Async)]
        [Alias("p")]
        [Summary("Pings the bot")]
        [CommandCategory(Category = CommandCategory.Fun)]
        public async Task PingAsync()
        {
            await ReplyAsync("", false,
                EmbedService.SuccesBuilder(
                    $"{Program.Client.CurrentUser.Username} is online and active | {Context.Client.Latency} ms"));
        }
    }
}
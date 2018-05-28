#region

using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Out : ModuleBase<SocketCommandContext>
    {
        [Command("out", RunMode = RunMode.Async)]
        [Alias("door")]
        [CommandCategory(Category = CommandCategory.Fun)]
        [Summary("Shows a user the door")]
        public async Task OutAsync(SocketGuildUser user)
        {
            await ReplyAsync($"{user.Mention} :point_right::skin-tone-1: :door:");
        }
    }
}
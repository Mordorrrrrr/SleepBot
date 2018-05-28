#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBot.Services.Fun;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Ass : ModuleBase<SocketCommandContext>
    {
        [CheckNsfw]
        [Command("ass", RunMode = RunMode.Async)]
        [CommandCategory(Category = CommandCategory.NSFW)]
        [Summary("Sends a random ass")]
        public async Task BoobsAsync()
        {
            await AssService.SendRandomAss(Context.Guild.GetTextChannel(Context.Channel.Id));
        }
    }
}
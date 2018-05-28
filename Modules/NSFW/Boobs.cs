#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services.Fun;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Boobs : ModuleBase<SocketCommandContext>
    {
        [CheckNsfw]
        [Command("boobs", RunMode = RunMode.Async)]
        [CommandCategory(Category = CommandCategory.NSFW)]
        [Summary("Sends some random boobs")]
        public async Task BoobsAsync()
        {
            await BoobsService.SendRandomBoobs(Context.Guild.GetTextChannel(Context.Channel.Id));
        }
    }
}
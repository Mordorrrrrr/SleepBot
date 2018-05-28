#region

using System;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class RandomNumber : ModuleBase<SocketCommandContext>
    {
        [Command("randomnumber")]
        [Alias("randn", "randomn", "randnumber", "rn")]
        [Summary("Generates a random number")]
        [CommandCategory(Category = CommandCategory.Tools)]
        public async Task RandomColorAsync(int min = int.MinValue, int max = int.MaxValue)
        {
            await ReplyAsync("", false,
                EmbedService
                    .SuccesBuilder($"Your new random number is {new Random().Next(min, max)}"));
        }
    }
}
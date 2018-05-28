#region

using System;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class RandomColor : ModuleBase<SocketCommandContext>
    {
        [Command("randomcolor")]
        [Alias("randc", "randomc", "randcolor", "rc")]
        [Summary("Generates a random color")]
        [CommandCategory(Category = CommandCategory.Tools)]
        public async Task RandomColorAsync()
        {
            var random = new Random();
            var r = random.Next(0, 255);
            var g = random.Next(0, 255);
            var b = random.Next(0, 255);

            await ReplyAsync("", false,
                EmbedService.SuccesBuilder($"You new random Color is RGB({r}, {g}, {b})", new Discord.Color(r, g, b)));
        }
    }
}
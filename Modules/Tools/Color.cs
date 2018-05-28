#region

using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Color : ModuleBase<SocketCommandContext>
    {
        [Command("color")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Lets you generate a color")]
        public async Task DecodeAsync(int red, int green, int blue)
        {
            var eb = new EmbedBuilder();
            eb.WithTitle("Color generated")
                .WithColor(new Discord.Color(red, green, blue))
                .WithDescription($"This is the color RGB({red}, {blue}, {green})");
            await ReplyAsync("", false, eb.Build());
        }
    }
}
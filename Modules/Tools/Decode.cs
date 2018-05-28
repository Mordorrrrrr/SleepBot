#region

using System;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Decode : ModuleBase<SocketCommandContext>
    {
        [Command("decode")]
        [Alias("dec", "dc")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Decodes a text")]
        public async Task DecodeAsync([Remainder] string text = null)
        {
            var bytetext = Convert.FromBase64String(text);
            text = Encoding.UTF8.GetString(bytetext);
            await ReplyAsync("", false,
                EmbedService.SuccesBuilder($"Decoded message: '{text}'"));
        }
    }
}
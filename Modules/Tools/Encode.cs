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
    public class Encode : ModuleBase<SocketCommandContext>
    {
        [Command("encode")]
        [Alias("enc", "enc", "ec", "e")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Encodes a text")]
        public async Task EncodeAsync([Remainder] string text)
        {
            Context.Message.DeleteAsync();
            var encodedText = Encoding.UTF8.GetBytes(text);
            text = Convert.ToBase64String(encodedText);
            var message = await ReplyAsync("", false,
                EmbedService.SuccesBuilder($"Your encoded text is: {text}"));
        }
    }
}
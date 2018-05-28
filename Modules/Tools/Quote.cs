#region

using System;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBot.Services.Tools;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Quote : ModuleBase<SocketCommandContext>
    {
        [Command("quote")]
        [Alias("q", "qu")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Sends a random quote")]
        public async Task EncodeAsync()
        {
            var tags = new[] {"Movies", "Famous"};
            await QuoteService.SendRandomQuoteAsync(tags[new Random().Next(0, tags.Length)],
                Context.Guild.GetTextChannel(Context.Channel.Id));
        }
    }
}
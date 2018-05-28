#region

using System;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class NudeGif : ModuleBase<SocketCommandContext>
    {
        [CheckNsfw]
        [Command("nudegif")]
        [Alias("gifnude", "gnude", "nugeg", "gn", "ng")]
        [Summary("Sends a random nude-gif")]
        [CommandCategory(Category = CommandCategory.NSFW)]
        public async Task PussyAsync()
        {
            await ReplyAsync(Strings.NsfwGifs[new Random().Next(0, Strings.NsfwGifs.Length)]);
        }
    }
}
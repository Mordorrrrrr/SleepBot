#region

using System;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Pussy : ModuleBase<SocketCommandContext>
    {
        [CheckNsfw]
        [Command("pussy")]
        [Summary("Shows a picture of a 'cat'")]
        [CommandCategory(Category = CommandCategory.NSFW)]
        public async Task PussyAsync()
        {
            await ReplyAsync(Strings.Pussys[new Random().Next(0, Strings.Pussys.Length)]);
        }
    }
}
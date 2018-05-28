#region

using System;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Porn : ModuleBase<SocketCommandContext>
    {
        [CheckNsfw]
        [Command("porn")]
        [Summary("Sends a random porn")]
        [CommandCategory(Category = CommandCategory.NSFW)]
        public async Task PussyAsync()
        {
            await Context.Channel.SendMessageAsync(Strings.NsfwVids[new Random().Next(0, Strings.NsfwVids.Length)]);
        }
    }
}
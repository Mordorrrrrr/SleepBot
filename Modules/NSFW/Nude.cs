#region

using System;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Nude : ModuleBase<SocketCommandContext>
    {
        [Command("nude")]
        [Summary("Sends a random nude")]
        [CommandCategory(Category = CommandCategory.NSFW)]
        public async Task PussyAsync()
        {
            if (!Context.Guild.GetTextChannel(Context.Channel.Id).IsNsfw)
            {
                await ReplyAsync("", false, EmbedService.ErrorBuilder("This command is only aviable in nsfw channels"));
                return;
            }

            await ReplyAsync(Strings.NsfwPictures[new Random().Next(0, Strings.NsfwPictures.Length)]);
        }
    }
}
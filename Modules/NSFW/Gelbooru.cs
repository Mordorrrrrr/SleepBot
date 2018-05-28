#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services.NSFW;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Gelbooru : ModuleBase<SocketCommandContext>
    {
        [CheckNsfw]
        [Command("gelbooru")]
        [Alias("gbooru", "gelb", "gb")]
        [Summary("Sends a random Gelbooru post")]
        [CommandCategory(Category = CommandCategory.NSFW)]
        public async Task GelbooruAsync([Remainder] string tags = null)
        {
            var taglist = new List<string>();
            if (tags != null) taglist = tags.Split(' ').ToList();
            await HentaiService.SendHentaiAsync(new HttpClient(), new Random(), HentaiService.NsfwType.Gelbooru,
                taglist.ToList(), Context.Channel);
        }
    }
}
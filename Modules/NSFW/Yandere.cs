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
    public class Yandere : ModuleBase<SocketCommandContext>
    {
        [CheckNsfw]
        [Command("yandere")]
        [Alias("y", "yan", "yand")]
        [Summary("Sends a random Yandere post")]
        [CommandCategory(Category = CommandCategory.NSFW)]
        public async Task YandereAsync([Remainder] string tags = null)
        {
            var taglist = new List<string>();
            if (tags != null) taglist = tags.Split(' ').ToList();
            await HentaiService.SendHentaiAsync(new HttpClient(), new Random(), HentaiService.NsfwType.Yandere,
                taglist.ToList(), Context.Channel);
        }
    }
}
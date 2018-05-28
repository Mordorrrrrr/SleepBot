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
    public class Konachan : ModuleBase<SocketCommandContext>
    {
        [CheckNsfw]
        [Command("konachan")]
        [Alias("kc")]
        [Summary("Sends a random Konachan post")]
        [CommandCategory(Category = CommandCategory.NSFW)]
        public async Task KonachanAsync([Remainder] string tags = null)
        {
            var taglist = new List<string>();
            if (tags != null) taglist = tags.Split(' ').ToList();
            await HentaiService.SendHentaiAsync(new HttpClient(), new Random(), HentaiService.NsfwType.Konachan,
                taglist.ToList(), Context.Channel);
        }
    }
}
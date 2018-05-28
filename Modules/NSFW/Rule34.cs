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
    public class Rule34 : ModuleBase<SocketCommandContext>
    {
        [CheckNsfw]
        [Command("rule34")]
        [Alias("rule")]
        [Summary("Sends a random Rule34 post")]
        [CommandCategory(Category = CommandCategory.NSFW)]
        public async Task Rule34Async([Remainder] string tags = null)
        {
            var taglist = new List<string>();
            if (tags != null) taglist = tags.Split(' ').ToList();
            await HentaiService.SendHentaiAsync(new HttpClient(), new Random(), HentaiService.NsfwType.Rule34,
                taglist.ToList(), Context.Channel);
        }
    }
}
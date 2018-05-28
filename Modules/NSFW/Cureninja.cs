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
    public class Cureninja : ModuleBase<SocketCommandContext>
    {
        [CheckNsfw]
        [Command("cureninja")]
        [Alias("cninja", "curen", "cn")]
        [Summary("Sends a random Cureninja post")]
        [CommandCategory(Category = CommandCategory.NSFW)]
        public async Task CureninjaAsync([Remainder] string tags = null)
        {
            var taglist = new List<string>();
            if (tags != null) taglist = tags.Split(' ').ToList();
            await HentaiService.SendHentaiAsync(new HttpClient(), new Random(), HentaiService.NsfwType.Cureninja,
                taglist.ToList(), Context.Channel);
        }
    }
}
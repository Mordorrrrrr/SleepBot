#region

using System;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;
using GiphyDotNet.Manager;
using GiphyDotNet.Model.Parameters;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Gif : ModuleBase<SocketCommandContext>
    {
        [Command("gif", RunMode = RunMode.Async)]
        [Alias("giphy", "gf")]
        [CommandCategory(Category = CommandCategory.Fun)]
        [Summary("Sends a random gif")]
        public async Task GifAsync([Remainder] string query)
        {
            var giphy = new Giphy(Variables.GiphyApiKey);
            var searchparameter = new SearchParameter
            {
                Query = query,
                Limit = 50
            };
            var gif = await giphy.GifSearch(searchparameter);
            var url = gif.Data[new Random().Next(0, gif.Data.Length)].Url;
            if (url == "")
                await ReplyAsync("", false, EmbedService.ErrorBuilder("Couldn't find a GIF"));
            else
                await Context.Channel.SendMessageAsync(url);
        }
    }
}
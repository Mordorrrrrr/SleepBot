#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using GiphyDotNet.Manager;
using GiphyDotNet.Model.Parameters;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class RandomGif : ModuleBase<SocketCommandContext>
    {
        [Command("randomgif", RunMode = RunMode.Async)]
        [Alias("randgif", "randg")]
        [Summary("Sends a random GIF")]
        [CommandCategory(Category = CommandCategory.Fun)]
        public async Task RandomGifAsync([Remainder] string tag = null)
        {
            var giphy = new Giphy(Variables.GiphyApiKey);
            var randomparameter = new RandomParameter
            {
                Format = "png"
            };
            if (tag != null) randomparameter.Tag = tag;
            var gif = await giphy.RandomGif(randomparameter);
            await Context.Channel.SendMessageAsync(gif.Data.ImageUrl);
        }
    }
}
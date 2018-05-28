#region

using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services;
using unirest_net.http;

#endregion

namespace DiscordBot.Services.Tools
{
    public class UrbanService
    {
        public static async Task SendDictionaryResult(string term, ISocketMessageChannel channel)
        {
            try
            {
                var termsearch = term.Replace(" ", "+");
                var result = Unirest
                    .get($"https://mashape-community-urban-dictionary.p.mashape.com/define?term={termsearch}")
                    .header("X-Mashape-Key", Variables.MarketplaceApiKey)
                    .header("Accept", "text/plain")
                    .asString();
                var data = UrbanData.UrbanData.FromJson(result.Body);
                var mostrateddata = data.UrbanList.First();
                var eb = new EmbedBuilder();
                eb.WithTitle($"Urban dictionary result for '{term}'")
                    .WithDescription(mostrateddata.Definition)
                    .WithColor(Color.Blue)
                    .AddField("Author", mostrateddata.Author, true)
                    .AddField("Rating", mostrateddata.ThumbsUp - mostrateddata.ThumbsDown, true)
                    .WithFooter($"Data by {mostrateddata.Permalink}");

                if (data.Tags.Length > 0) eb.AddField("Tags", string.Join(", ", data.Tags));
                if (data.Sounds.Length > 0) eb.AddField("Pronunciation example", data.Sounds.First(), true);
                await channel.SendMessageAsync("", false, eb.Build());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await channel.SendMessageAsync("", false, EmbedService.ErrorBuilder("Couldn't find any data"));
            }
        }
    }
}
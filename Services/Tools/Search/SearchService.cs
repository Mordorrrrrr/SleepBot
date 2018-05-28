#region

using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT.Core;
using unirest_net.http;

#endregion

namespace DiscordBOT.Services.Tools.Search
{
    public class SearchService
    {
        public static async Task SendSearchResultAsync(string query, SocketTextChannel channel)
        {
            try
            {
                query = query.Replace(" ", "+");
                var response = Unirest.get($"https://faroo-faroo-web-search.p.mashape.com/api?q={query}")
                    .header("X-Mashape-Key", Variables.MarketplaceApiKey)
                    .header("Accept", "application/json")
                    .asString();
                var data = SearchData.SearchData.FromJson(response.Body);
                var eb = new EmbedBuilder();
                eb.WithTitle($"Results for '{data.Query}'")
                    .WithColor(Color.Blue);
                var upper = data.Results.Length > 5 ? 5 : data.Results.Length;
                var desc = "";
                for (var i = 0; i < upper; i++)
                {
                    var specificdata = data.Results[i];
                    var title = specificdata.Title.Length > 256
                        ? string.Join("", specificdata.Title.Take(253))
                        : specificdata.Title;
                    desc += $"❯ [**{title}**]({specificdata.Url})\nFrom: {specificdata.Domain}\n";
                }

                eb.WithDescription(desc);

                await channel.SendMessageAsync("", false, eb.Build());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await channel.SendMessageAsync("", false, EmbedService.ErrorBuilder("Couldn't find any results"));
            }
        }
    }
}
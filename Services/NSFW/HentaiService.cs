#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord;

#endregion

namespace DiscordBOT.Services.NSFW
{
    public class HentaiService
    {
        public enum NsfwType
        {
            Rule34,
            Yandere,
            Gelbooru,
            Konachan,
            Cureninja
        }

        public static async Task SendHentaiAsync(HttpClient HttpClient, Random Random, NsfwType NsfwType,
            List<string> Tags, IMessageChannel channel)
        {
            string Url = null;
            string Result = null;
            MatchCollection Matches;
            Tags = Tags == new List<string>() ? new[] {"boobs", "tits", "ass", "sexy", "neko"}.ToList() : Tags;
            switch (NsfwType)
            {
                case NsfwType.Gelbooru:
                    Url =
                        $"http://gelbooru.com/index.php?page=dapi&s=post&q=index&limit=200&tags={string.Join("+", Tags.Select(x => x.Replace(" ", "_")))}";
                    break;
                case NsfwType.Rule34:
                    Url =
                        $"http://rule34.xxx/index.php?page=dapi&s=post&q=index&limit=200&tags={string.Join("+", Tags.Select(x => x.Replace(" ", "_")))}";
                    break;
                case NsfwType.Cureninja:
                    Url =
                        $"https://cure.ninja/booru/api/json?f=a&o=r&s=1&q={string.Join("+", Tags.Select(x => x.Replace(" ", "_")))}";
                    break;
                case NsfwType.Konachan:
                    Url =
                        $"http://konachan.com/post?page={Random.Next(0, 5)}&tags={string.Join("+", Tags.Select(x => x.Replace(" ", "_")))}";
                    break;
                case NsfwType.Yandere:
                    Url =
                        $"https://yande.re/post.xml?limit=25&page={Random.Next(0, 15)}&tags={string.Join("+", Tags.Select(x => x.Replace(" ", "_")))}";
                    break;
            }

            var Get = await HttpClient.GetStringAsync(Url).ConfigureAwait(false);
            switch (NsfwType)
            {
                case NsfwType.Yandere:
                case NsfwType.Gelbooru:
                case NsfwType.Rule34:
                    Matches = Regex.Matches(Get, "file_url=\"(.*?)\" ");
                    break;
                case NsfwType.Cureninja:
                    Matches = Regex.Matches(Get, "\"url\":\"(.*?)\"");
                    break;
                case NsfwType.Konachan:
                    Matches = Regex.Matches(Get, "<a class=\"directlink smallimg\" href=\"(.*?)\"");
                    break;
                default:
                    Matches = Regex.Matches(Get, "\"url\":\"(.*?)\"");
                    break;
            }

            switch (NsfwType)
            {
                case NsfwType.Konachan:
                case NsfwType.Gelbooru:
                case NsfwType.Yandere:
                case NsfwType.Rule34:
                    Result = $"{Matches[Random.Next(0, Matches.Count)].Groups[1].Value}";
                    break;
                case NsfwType.Cureninja:
                    Result = Matches[Random.Next(0, Matches.Count)].Groups[1].Value.Replace("\\/", "/");
                    break;
            }

            Result = Result.EndsWith("/") ? Result.Substring(0, Result.Length - 1) : Result;
            await channel.SendMessageAsync(Result);
        }
    }
}
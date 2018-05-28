#region

using System;
using System.Net.Http;
using System.Threading.Tasks;
using BooobsData;
using Discord.WebSocket;

#endregion

namespace DiscordBOT.Services.Fun
{
    public class BoobsService
    {
        public static async Task SendRandomBoobs(SocketTextChannel channel)
        {
            var random = new Random();
            var firstvalue = random.Next(1, 1000);
            var data = BoobsData.FromJson(
                await new HttpClient().GetStringAsync(
                    $"http://api.oboobs.ru/boobs/{random.Next(1, 12755)}"));
            await channel.SendMessageAsync(
                $"http://media.oboobs.ru/{data[0].Preview}");
        }
    }
}
#region

using System;
using System.Net.Http;
using System.Threading.Tasks;
using BooobsData;
using Discord.WebSocket;

#endregion

namespace DiscordBot.Services.Fun
{
    public class AssService
    {
        public static async Task SendRandomAss(SocketTextChannel channel)
        {
            var random = new Random();
            var firstvalue = random.Next(1, 1000);
            var data = BoobsData.FromJson(
                await new HttpClient().GetStringAsync(
                    $"http://api.obutts.ru/butts/{random.Next(1, 5817)}"));
            await channel.SendMessageAsync(
                $"http://media.obutts.ru/{data[0].Preview}");
        }
    }
}
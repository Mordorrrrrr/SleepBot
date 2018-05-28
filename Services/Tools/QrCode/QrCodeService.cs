#region

using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBOT.Core;
using unirest_net.http;

#endregion

namespace DiscordBOT.Services.Tools.QrCode
{
    public class QrCodeService
    {
        public static async Task SendQrCodeAsync(string text, ISocketMessageChannel channel)
        {
            try
            {
                text = text.Replace(" ", "+");
                var response = Unirest
                    .get(
                        $"https://pierre2106j-qrcode.p.mashape.com/api?backcolor=ffffff&ecl=L+%7C+M%7C+Q+%7C+H&forecolor=000000&pixel=10&text={text}&type=text")
                    .header("X-Mashape-Key", Variables.MarketplaceApiKey)
                    .header("Accept", "text/plain")
                    .asString();
                await channel.SendMessageAsync(response.Body);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
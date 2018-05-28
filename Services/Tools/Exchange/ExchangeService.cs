#region

using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBOT.Core;
using unirest_net.http;

#endregion

namespace DiscordBOT.Services.Tools.Exchange
{
    public class ExchangeService
    {
        public static async Task SendExchangeAsync(string fromc, string toc, long amount, SocketTextChannel channel)
        {
            try
            {
                var response = Unirest
                    .get(
                        $"https://currency-exchange.p.mashape.com/exchange?from={fromc.ToUpper()}&q={amount}&to={toc.ToUpper()}")
                    .header("X-Mashape-Key", Variables.MarketplaceApiKey)
                    .header("Accept", "text/plain")
                    .asString();
                await channel.SendMessageAsync("", false,
                    EmbedService.SuccesBuilder(
                        $"'{amount} {fromc.ToUpper()}' are '{response.Body} {toc.ToUpper()}'"));
            }
            catch (Exception e)
            {
                await channel.SendMessageAsync("", false,
                    EmbedService.ErrorBuilder($"Couldn't convert from '{fromc.ToUpper()}' to '{toc.ToUpper()}'"));
            }
        }

        public static async Task SendCurrencysAsync(SocketTextChannel channel)
        {
            await channel.SendMessageAsync("", false,
                EmbedService.InfoBuilder("Supported currencys", string.Join(", ", await GetSupportedCurrencies())));
        }

        public static async Task<string[]> GetSupportedCurrencies()
        {
            var response = Unirest.get("https://currency-exchange.p.mashape.com/listquotes")
                .header("X-Mashape-Key", Variables.MarketplaceApiKey)
                .header("Accept", "text/plain")
                .asString();
            var data = ExchangeData.ExchangeData.FromJson(response.Body);
            return data;
        }
    }
}
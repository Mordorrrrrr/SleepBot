#region

using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services;
using PingData;
using unirest_net.http;

#endregion

namespace IpData
{
    public class IpService
    {
        public static async Task SendIpInformationAsync(string ip, SocketTextChannel channel)
        {
            try
            {
                var response = Unirest
                    .get(
                        $"https://chrislim2888-ip-address-geolocation.p.mashape.com/?key={Variables.IpApi}&format=json&ip={ip}")
                    .header("X-Mashape-Key", Variables.MarketplaceApiKey)
                    .header("Accept", "text/plain")
                    .asString();
                var data = IpData.FromJson(response.Body);
                var valid = data.StatusCode == "OK" ? "Yes" : "No";
                var eb = new EmbedBuilder();
                var pingresult = await PingService.GetPingResult(ip);
                eb.WithTitle($"IP lookup for {data.IpAddress}")
                    .WithColor(Color.Blue)
                    .WithDescription(
                        $"Country: {data.CountryName} ({data.CountryCode})\nRegion: {data.RegionName ?? "none"}\nCity: {data.CityName}\nLatency: {pingresult.time}ms\nLatitude: {data.Latitude}\nLongitude: {data.Longitude}\nTimezone: {data.TimeZone}");
                await channel.SendMessageAsync("", false, eb.Build());
            }
            catch (Exception)
            {
                await channel.SendMessageAsync("", false, EmbedService.ErrorBuilder("Couldn't find IP"));
            }
        }
    }
}
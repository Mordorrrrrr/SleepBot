#region

using System.IO;
using System.Threading.Tasks;
using Discord;
using DiscordBOT.Services.External;

#endregion

namespace DiscordBOT.Core
{
    public class Variables
    {
        public static string BotToken;
        public static string BotPrefix;
        public static string GiphyApiKey;

        public static string BotDiscordInviteLink;

        public static string YtApiKey;
        public static string LoLAPiKey;
        public static string MarketplaceApiKey;
        public static string IpApi;

        public static string DefaultUserJoined;
        public static string DefaultUserLeft;
        public static string DefaultLevelUpMessage;

        public async Task UpdateVariables()
        {
            ConfigurationService.Initialize();
            var variables = await ConfigurationService.LoadConfig();
            if (variables == null)
            {
                await Program.LogAsync(new LogMessage(LogSeverity.Critical, "none", "Couldn't load config.json"));
                throw new IOException("File not found");
            }

            variables.TryGetValue("botToken", out BotToken);
            variables.TryGetValue("botPrefix", out BotPrefix);
            variables.TryGetValue("giphyApiKey", out GiphyApiKey);
            variables.TryGetValue("botDiscordInviteLink", out BotDiscordInviteLink);
            variables.TryGetValue("YTApiKey", out YtApiKey);
            variables.TryGetValue("LoLApiKey", out LoLAPiKey);
            variables.TryGetValue("defaultUserJoined", out DefaultUserJoined);
            variables.TryGetValue("defaultUserLeft", out DefaultUserLeft);
            variables.TryGetValue("defaultLevelUpMessage", out DefaultLevelUpMessage);
            variables.TryGetValue("marketplaceApiKey", out MarketplaceApiKey);
            variables.TryGetValue("IpApi", out IpApi);
        }
    }
}
#region

using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services;
using DiscordBOT.Services.Administration;

#endregion

namespace DiscordBOT.Modules.Administration
{
    public class NsfwService
    {
        public static async Task SendNsfwAsync(SocketGuild guild, string action, ISocketMessageChannel channel)
        {
            switch (action)
            {
                case "enable":
                case "enabled":
                case "e":
                case "en":
                case "true":
                case "on":
                    DatabaseService.SetNsfwEnabled(guild.Id, true);
                    await channel.SendMessageAsync("", false,
                        EmbedService.SuccesBuilder($"Successfully changed nsfw to enabled"));
                    break;
                case "disable":
                case "disabled":
                case "d":
                case "dis":
                case "false":
                case "off":
                    DatabaseService.SetNsfwEnabled(guild.Id, false);
                    await channel.SendMessageAsync("", false,
                        EmbedService.SuccesBuilder($"Successfully changed nsfw to disabled"));
                    break;
                default:
                    await channel.SendMessageAsync("", false,
                        EmbedService.InfoBuilder("Usage nsfw", $"{Variables.BotPrefix}nsfw <enabled/disabled>"));
                    break;
            }
        }

        public static async Task<bool> GetNsfw(SocketGuild guild)
        {
            var state = await DatabaseService.GetNsfwEnabled(guild.Id);
            return state;
        }

        public static async Task SetNsfwEnabled(SocketGuild guild, bool state)
        {
            await DatabaseService.SetNsfwEnabled(guild.Id, state);
        }
    }
}
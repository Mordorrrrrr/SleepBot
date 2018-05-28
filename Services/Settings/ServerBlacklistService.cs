#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;

#endregion

namespace DiscordBOT.Services.Administration
{
    public static class ServerBlacklistService
    {
        public static async Task AddToBlacklistedChannels(SocketGuild guild, List<ISocketMessageChannel> channels,
            ISocketMessageChannel chat)
        {
            DatabaseService.AddToBlacklistedChannelIDs(guild.Id, channels.Select(x => x.Id));
            await chat.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully added {channels.Count} channels to the blacklist"));
        }

        public static async Task RemoveFromBlacklistedChannels(SocketGuild guild, List<ISocketMessageChannel> channels,
            ISocketMessageChannel chat)
        {
            DatabaseService.RemoveFromBlacklistedChannelIDs(guild.Id, channels.Select(x => x.Id));

            await chat.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully removed {channels.Count} channels to the blacklist"));
        }

        public static async Task ClearBlacklistedChannels(SocketGuild guild, ISocketMessageChannel chat)
        {
            DatabaseService.SetBlacklistedChannelIDs(guild.Id, new List<ulong>());

            await chat.SendMessageAsync("", false,
                EmbedService.SuccesBuilder("Successfully removed all channels to the blacklist"));
        }

        public static async Task<List<string>> GetBlacklistChannelNamesAsync(SocketGuild guild)
        {
            var channelids = await DatabaseService.GetBlacklistedChannelIDs(guild.Id);
            var channelnames = new List<string>();
            var falsechannelids = new List<ulong>();
            foreach (var id in channelids)
            {
                var channel = guild.GetTextChannel(id);
                if (channel != default(SocketTextChannel))
                    channelnames.Add(channel.Mention);
                else
                    falsechannelids.Add(id);
            }

            return channelnames;
        }
    }
}
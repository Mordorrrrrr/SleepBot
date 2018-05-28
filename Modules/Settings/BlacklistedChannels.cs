#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services;
using DiscordBOT.Services.Administration;

#endregion

namespace DiscordBOT.Modules.Administration
{
    public class BlacklistedChannels : ModuleBase<SocketCommandContext>
    {
        [Command("blacklist")]
        [Alias("bl", "blackl", "blist")]
        [CommandCategory(Category = CommandCategory.Settings)]
        [RequireUserPermission(GuildPermission.Administrator)]
        [Summary("Adds or removes channels from the blacklist")]
        public async Task BlacklistAsync(string action = null, params ISocketMessageChannel[] channels)
        {
            if (action == null)
            {
                var channelids = await DatabaseService.GetBlacklistedChannelIDs(Context.Guild.Id);
                var channelnames = new List<string>();
                var falsechannelids = new List<ulong>();
                foreach (var id in channelids)
                    try
                    {
                        channelnames.Add(Context.Guild.GetTextChannel(id).Mention);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        falsechannelids.Add(id);
                    }

                var channelmentions = string.Join(", ",
                    await ServerBlacklistService.GetBlacklistChannelNamesAsync(Context.Guild));

                DatabaseService.RemoveFromBlacklistedChannelIDs(Context.Guild.Id, falsechannelids);
                if (channelmentions != "")
                    await ReplyAsync("", false,
                        EmbedService.SuccesBuilder(
                            $"The servers blacklist contains: {channelmentions}"));
                else
                    await ReplyAsync("", false, EmbedService.ErrorBuilder("No blacklisted channels set"));
            }
            else if (string.Equals(action, "add", StringComparison.CurrentCultureIgnoreCase))
            {
                await ServerBlacklistService.AddToBlacklistedChannels(Context.Guild, channels.ToList(),
                    Context.Channel);
            }
            else if (string.Equals(action, "remove", StringComparison.CurrentCultureIgnoreCase))
            {
                await ServerBlacklistService.RemoveFromBlacklistedChannels(Context.Guild, channels.ToList(),
                    Context.Channel);
            }
            else if (string.Equals(action, "clear", StringComparison.CurrentCultureIgnoreCase))
            {
                await ServerBlacklistService.ClearBlacklistedChannels(Context.Guild, Context.Channel);
            }
            else
            {
                await ReplyAsync("", false,
                    EmbedService.ErrorBuilder("Action not found; Aviable actions: add, remove, clear"));
            }
        }
    }
}
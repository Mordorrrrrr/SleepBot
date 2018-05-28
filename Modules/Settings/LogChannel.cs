#region

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
    public class LogChannel : ModuleBase<SocketCommandContext>
    {
        [Command("logchannel")]
        [Alias("lc", "logc", "lchannel", "lochannel")]
        [CommandCategory(Category = CommandCategory.Settings)]
        [RequireUserPermission(GuildPermission.Administrator)]
        [Summary("Sets the server logchannel")]
        public async Task LogChannelAsync(SocketGuildChannel channel = null)
        {
            if (channel == null)
            {
                var channelname = await ServerLogChannelService.GetLogChannelId(Context.Guild) == default(ulong)
                    ? "not set"
                    : (Context.Guild.GetTextChannel(await ServerLogChannelService.GetLogChannelId(Context.Guild)) as
                        ITextChannel).Mention;
                await ReplyAsync("", false,
                    EmbedService.SuccesBuilder(
                        $"The server logchannel is {channelname}"));
            }
            else
            {
                await ServerLogChannelService.SetLogChannel(Context.Guild, channel,
                    Context.Channel as SocketTextChannel);
            }
        }
    }
}
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
    public class WelcomeChannel : ModuleBase<SocketCommandContext>
    {
        [Command("welcomechannel")]
        [Alias("wc", "welcomec", "wchannel", "welchannel")]
        [CommandCategory(Category = CommandCategory.Settings)]
        [RequireUserPermission(GuildPermission.Administrator)]
        [Summary("Sets the server welcomechannel")]
        public async Task WelcomeChannelAsync(SocketGuildChannel channel = null)
        {
            if (channel == null)
            {
                var channelname = await WelcomeChannelService.GetWelcomeChannelId(Context.Guild) == default(ulong)
                    ? "not set"
                    : (Context.Guild.GetTextChannel(await WelcomeChannelService.GetWelcomeChannelId(Context.Guild)) as
                        ITextChannel).Mention;
                await ReplyAsync("", false,
                    EmbedService.SuccesBuilder(
                        $"The server welcomechannel is {channelname}"));
            }
            else
            {
                await WelcomeChannelService.SetWelcomeChannel(Context.Guild, channel,
                    Context.Channel as SocketTextChannel);
            }
        }
    }
}
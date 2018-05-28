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
    public class Prefix : ModuleBase<SocketCommandContext>
    {
        [Command("prefix")]
        [Alias("pre")]
        [CommandCategory(Category = CommandCategory.Settings)]
        [RequireUserPermission(GuildPermission.Administrator)]
        [Summary("Sets the server prefix")]
        public async Task PrefixAsync(string prefix = null)
        {
            if (prefix == null)
                await ReplyAsync("", false,
                    EmbedService.SuccesBuilder(
                        $"The server prefix is '{await ServerPrefixService.GetServerPrefix(Context.Guild)}'"));
            else
                await ServerPrefixService.SetServerPrefix(Context.Guild, prefix, Context.Channel as SocketTextChannel);
        }
    }
}
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
    public class LeaveMessage : ModuleBase<SocketCommandContext>
    {
        [Command("leavemessage")]
        [Alias("lm", "leavem", "lmessage", "leavmessage", "lmsg", "leavmsg")]
        [CommandCategory(Category = CommandCategory.Settings)]
        [RequireUserPermission(GuildPermission.Administrator)]
        [Summary("Sets the server leavemessage | You can use %mention%, %user%, %server%")]
        public async Task LeaveMessageAsync([Remainder] string message = null)
        {
            switch (message)
            {
                case null:
                    var leavemessage = await ServerAnnounceService.GetLeaveMessage(Context.Guild);
                    await ReplyAsync("", false,
                        EmbedService.SuccesBuilder(
                            $"The server leavemessage is '{leavemessage}'"));
                    break;
                case "default":
                    await ServerAnnounceService.SetLeaveMessage(Context.Guild, "",
                        Context.Channel as SocketTextChannel);
                    break;
                default:
                    await ServerAnnounceService.SetLeaveMessage(Context.Guild, message,
                        Context.Channel as SocketTextChannel);
                    break;
            }
        }
    }
}
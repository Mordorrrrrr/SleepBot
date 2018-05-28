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
    public class WelcomeMessage : ModuleBase<SocketCommandContext>
    {
        [Command("welcomemessage")]
        [Alias("wm", "welcomem", "wmessage", "welmessage", "wmsg", "welmsg")]
        [CommandCategory(Category = CommandCategory.Settings)]
        [RequireUserPermission(GuildPermission.Administrator)]
        [Summary("Sets the server welcomemessage | You can use %mention%, %user%, %server%")]
        public async Task WelcomeMessageAsync([Remainder] string message = null)
        {
            switch (message)
            {
                case null:
                    var welcomemessage = await ServerAnnounceService.GetWelcomeMessage(Context.Guild);
                    await ReplyAsync("", false,
                        EmbedService.SuccesBuilder(
                            $"The server welcomemessage is '{welcomemessage}'"));
                    break;
                case "default":
                    await ServerAnnounceService.SetWelcomeMessage(Context.Guild, "",
                        Context.Channel as SocketTextChannel);
                    break;
                default:
                    await ServerAnnounceService.SetWelcomeMessage(Context.Guild, message,
                        Context.Channel as SocketTextChannel);
                    break;
            }
        }
    }
}
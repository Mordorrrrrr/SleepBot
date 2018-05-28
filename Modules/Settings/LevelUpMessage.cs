#region

using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services;
using DiscordBOT.Services.External;

#endregion

namespace DiscordBOT.Modules.Administration
{
    public class LevelUpMessage : ModuleBase<SocketCommandContext>
    {
        [Command("levelupmessage")]
        [Alias("lum", "levelupm", "lupmessage", "lumessage", "lumsg", "lupmsg")]
        [CommandCategory(Category = CommandCategory.Settings)]
        [RequireUserPermission(GuildPermission.Administrator)]
        [Summary("Sets the server levelupmessage | You can use %mention%, %user%, %server%, %level%")]
        public async Task LevelUpMessageAsync([Remainder] string message = null)
        {
            switch (message)
            {
                case null:
                    var leavemessage = await LevelService.GetLevelUpMessage(Context.Guild);
                    await ReplyAsync("", false,
                        EmbedService.SuccesBuilder(
                            $"The server levelupmessage is '{leavemessage}'"));
                    break;
                case "default":
                    await LevelService.SetLevelUpMessage(Context.Guild, "",
                        Context.Channel as SocketTextChannel);
                    break;
                default:
                    await LevelService.SetLevelUpMessage(Context.Guild, message,
                        Context.Channel as SocketTextChannel);
                    break;
            }
        }
    }
}
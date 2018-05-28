#region

using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Administration
{
    public class Nsfw : ModuleBase<SocketCommandContext>
    {
        [Command("nsfw")]
        [Alias("setnsfw")]
        [CommandCategory(Category = CommandCategory.Settings)]
        [RequireUserPermission(GuildPermission.Administrator)]
        [Summary("Sets the server nsfw to enabled/disabled")]
        public async Task NsfwAsync(string action = "")
        {
            action = action.ToLower();
            await NsfwService.SendNsfwAsync(Context.Guild, action, Context.Channel);
        }
    }
}
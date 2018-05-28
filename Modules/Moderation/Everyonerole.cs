using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services;

namespace DiscordBOT.Modules.Moderation
{
    public class Everyonerole : ModuleBase<SocketCommandContext>
    {
        [Command("everyonerole", RunMode = RunMode.Async)]
        [Alias("erole", "everyoner", "er")]
        [CommandCategory(Category = CommandCategory.Moderation)]
        [Summary("Sets the servers everyone role")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(GuildPermission.Administrator)]
        public async Task EveryoneroleAsync([Remainder] string role)
        {
            var spefificRole = Context.Guild.Roles.Where(x => x.Name == role || x.Mention == role);
            if (!spefificRole.Any())
            {
                await ReplyAsync("", false, EmbedService.ErrorBuilder($"Couldn't find the role '{role}'"));
                return;
            }

            if (spefificRole.Count() > 1)
            {
                await ReplyAsync("", false,
                    EmbedService.ErrorBuilder($"There are multiple roles with the name '{role}'"));
                return;
            }

        }
    }
}
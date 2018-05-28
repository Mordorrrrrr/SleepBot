using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;

namespace DiscordBOT.Modules.Administration
{
    public class Everyonerole : ModuleBase<SocketCommandContext>
    {
        [Command("everyonerole", RunMode = RunMode.Async)]
        [Alias("erole", "everyrole", "eor", "er")]
        [CommandCategory(Category = CommandCategory.Fun)]
        [Summary("Sets the everyonerole")]
        public async Task EveryoneroleAsync([Remainder] string role)
        {
            var specificrole = Context.Guild.Roles.Where(x =>
                string.Equals(x.Name, role, StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(x.Mention, role, StringComparison.CurrentCultureIgnoreCase));
            if (specificrole.Count() > 1)
            {
                await ReplyAsync("", false,
                    EmbedService.ErrorBuilder($"There are multiple roles with the name '{role}'"));
                return;
            }

            if (specificrole.Count() == 0) await ReplyAsync("", false, EmbedService.ErrorBuilder($"Couldn't find th"));
        }
    }
}
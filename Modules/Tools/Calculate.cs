#region

using System;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services;
using NCalc;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Calculate : ModuleBase<SocketCommandContext>
    {
        [Command("calculate")]
        [Alias("calc")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Solves a math term")]
        public async Task CalculateAsync([Remainder] string term)
        {
            term = term.Replace("x", "*");
            try
            {
                await ReplyAsync("", false,
                    EmbedService.SuccesBuilder($"The solution is: '{new Expression(term).Evaluate()}'"));
            }
            catch (Exception e)
            {
                await ReplyAsync("", false, EmbedService.ErrorBuilder($"Couldn't solve '{term}'"));
            }
        }
    }
}
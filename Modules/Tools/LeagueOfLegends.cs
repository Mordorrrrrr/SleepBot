#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services.Tools;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class LeagueOfLegends : ModuleBase<SocketCommandContext>
    {
        [Command("lolstats")]
        [Alias("lol", "league", "leaguestats")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Shows a lol profile")]
        public async Task EncodeAsync(string region, [Remainder] string summonername)
        {
            await LoLService.SendLoLStatistics(region, summonername, Context.Guild.GetTextChannel(Context.Channel.Id));
        }
    }
}
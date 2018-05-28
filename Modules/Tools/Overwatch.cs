#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services.Tools.Overwatch;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Overwatch : ModuleBase<SocketCommandContext>
    {
        [Command("overwatchstats")]
        [Alias("ows", "ow")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Sends Overwatch statistics")]
        public async Task OverwatchAsync(string platform, string region, string battletag)
        {
            await OverwatchService.SendOverwatchStatsAsync(platform, region, battletag,
                Context.Guild.GetUser(Context.User.Id), Context.Channel);
        }
    }
}
#region

using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.General
{
    public class Statistics : ModuleBase<SocketCommandContext>
    {
        [Command("statistics", RunMode = RunMode.Async)]
        [Alias("stats", "statistic")]
        [CommandCategory(Category = CommandCategory.General)]
        [Summary("Shows information about the BOT")]
        public async Task StatisticsAsync()
        {
            var statisticsBuilder = new EmbedBuilder();
            statisticsBuilder.WithAuthor($"{Program.Client.CurrentUser.Username} statistics",
                    Program.Client.CurrentUser.GetAvatarUrl())
                .WithThumbnailUrl(Program.Client.CurrentUser.GetAvatarUrl())
                .WithColor(Color.Blue)
                .AddField("Guilds", Program.Client.Guilds.Count, true)
                .AddField("Users", Program.Client.Guilds.Sum(g => g.Users.Count(u => !u.IsBot)), true)
                .AddField("Text channels", Program.Client.Guilds.Sum(g => g.TextChannels.Count), true)
                .AddField("Voice channels", Program.Client.Guilds.Sum(g => g.VoiceChannels.Count), true)
                .AddField("Status", Program.Client.Status.ToString(), true)
                .AddField("Latency", Program.Client.Latency, true)
                .AddField("Commands", Program.CommandService.Commands.Count(), true);

            await ReplyAsync("", false, statisticsBuilder.Build());
        }
    }
}
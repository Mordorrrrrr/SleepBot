#region

using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.General
{
    public class ServerStatistics : ModuleBase<SocketCommandContext>
    {
        [Command("serverstatistics", RunMode = RunMode.Async)]
        [Alias("serverstatistic", "serverstats", "servers", "sstatistics", "sstatistic", "sstats", "ss")]
        [CommandCategory(Category = CommandCategory.General)]
        [Summary("Shows information about the current server")]
        public async Task GuildStatisticsAsync()
        {
            var guildstatisticsBuilder = new EmbedBuilder();
            guildstatisticsBuilder.WithAuthor($"{Context.Guild.Name} information", Context.Guild.IconUrl)
                .WithColor(Color.Blue)
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .AddField("Text channels", Context.Guild.TextChannels.Count, true)
                .AddField("Voice channels", Context.Guild.VoiceChannels.Count, true)
                .AddField("Members", Context.Guild.Users.Count(x => !x.IsBot), true)
                .AddField("Bots", Context.Guild.Users.Count(u => u.IsBot), true)
                .AddField("Owner", Context.Guild.Owner.Mention, true)
                .AddField("Roles", Context.Guild.Roles.Count - 1, true)
                .AddField("Created at", await Util.GetDate(Context.Guild.CreatedAt.Date), true)
                .AddField("Server ID", Context.Guild.Id, true)
                .AddField("Administration users",
                    Context.Guild.Users.Count(x => x.GuildPermissions.Has(GuildPermission.Administrator) && !x.IsBot),
                    true)
                .AddField("Server region", Context.Guild.VoiceRegionId, true);

            await ReplyAsync("", false, guildstatisticsBuilder.Build());
        }
    }
}
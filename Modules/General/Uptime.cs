#region

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.General
{
    public class Uptime : ModuleBase<SocketCommandContext>
    {
        [Command("uptime", RunMode = RunMode.Async)]
        [Alias("upt", "ut")]
        [CommandCategory(Category = CommandCategory.General)]
        [Summary("Shows the bot's uptime")]
        public async Task UptimeAsync()
        {
            var eb = new EmbedBuilder();
            eb.WithColor(Color.Blue);
            eb.WithAuthor($"{Program.Client.CurrentUser.Username} Uptime", Program.Client.CurrentUser.GetAvatarUrl())
                .AddField("Last restart",
                    await Util.GetDate(Process.GetCurrentProcess().StartTime))
                .AddField("Online since",
                    await Util.GetTimePeriod(DateTime.Now - Process.GetCurrentProcess().StartTime));
            await ReplyAsync("", false, eb.Build());
        }
    }
}
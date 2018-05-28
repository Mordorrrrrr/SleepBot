#region

using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.General
{
    public class Invite : ModuleBase<SocketCommandContext>
    {
        [Command("invite", RunMode = RunMode.Async)]
        [Alias("inv", "i")]
        [CommandCategory(Category = CommandCategory.General)]
        [Summary("Shows the bot invite link and discord link")]
        public async Task InviteAsync()
        {
            var eb = new EmbedBuilder();
            eb.WithAuthor($"{Context.Client.CurrentUser.Username}")
                .WithDescription(
                    $"❯ [Bot](https://discordapp.com/oauth2/authorize?client_id={Context.Client.CurrentUser.Id}&scope=bot&permissions=2146958591)\n❯ [Discord]({Variables.BotDiscordInviteLink})")
                .WithColor(Color.Blue);
            await ReplyAsync("", false, eb.Build());
        }
    }
}
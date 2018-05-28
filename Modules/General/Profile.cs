#region

using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services.External;

#endregion

namespace DiscordBOT.Modules.General
{
    public class Profile : ModuleBase<SocketCommandContext>
    {
        [Command("profile", RunMode = RunMode.Async)]
        [Alias("p", "pr")]
        [CommandCategory(Category = CommandCategory.General)]
        [Summary("Shows a user's profile")]
        public async Task ProfileAsync(SocketGuildUser user = null)
        {
            if (user == null) user = (SocketGuildUser) Context.User;

            var eb = new EmbedBuilder();

            var roles = user.Roles.ToList();
            roles.RemoveAt(0);
            var role = string.Join(", ", roles);

            eb.WithAuthor(user.Username,
                    user.GetAvatarUrl() == null
                        ? $"https://cdn.discordapp.com/embed/avatars/{user.DiscriminatorValue % 5}.png"
                        : user.GetAvatarUrl())
                .WithColor(Color.Blue)
                .WithThumbnailUrl(user.GetAvatarUrl() ??
                                  $"https://cdn.discordapp.com/embed/avatars/{user.DiscriminatorValue % 5}.png")
                .AddField("ID", user.Id, true)
                .AddField("Leveling",
                    $"Level {await LevelService.GetLevel(user)}\nXP: {await LevelService.GetXP(user)} / {await LevelService.GetNeededXP(user)}",
                    true)
                .AddField("Joined",
                    $"{user.CreatedAt.Day}.{user.CreatedAt.Month}.{user.CreatedAt.Year} {user.CreatedAt.Hour}:{user.CreatedAt.Minute}:{user.CreatedAt.Second}",
                    true)
                .AddField("Is a bot", user.IsBot ? "Yes" : "No", true)
                .AddField("Roles", role == "" ? "none" : role, true);


            await ReplyAsync("", false, eb.Build());
        }
    }
}
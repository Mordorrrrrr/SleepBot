#region

using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Modules.Administration;
using DiscordBOT.Services.Administration;

#endregion

namespace DiscordBOT.Services
{
    public class HelpService
    {
        public async Task HelpListAsync(ISocketMessageChannel channel, SocketGuild guild)
        {
            var commandcount = 0;
            var helpBuilder = new EmbedBuilder();
            helpBuilder.WithAuthor($"{Program.Client.CurrentUser.Username} command manual",
                    Program.Client.CurrentUser.GetAvatarUrl())
                .WithDescription(
                    $"Use {await ServerPrefixService.GetServerPrefix(guild)}help <command> to get information about a specific command")
                .WithColor(Color.Blue);
            var nsfwstate = await NsfwService.GetNsfw(guild);
            foreach (var e in Enum.GetValues(typeof(CommandCategory)))
            {
                if ((CommandCategory) e == CommandCategory.NSFW)
                    if (!nsfwstate)
                        continue;
                var commandList = (from c in Program.CommandService.Commands
                    let attribute =
                        (CommandCategoryAttribute) c.Attributes.FirstOrDefault(x =>
                            x is CommandCategoryAttribute)
                    where attribute?.Category == (CommandCategory) e
                    select c.Name).ToList();
                commandList.Sort();
                if (commandList.Count == 0) continue;
                var commandString = string.Join(", ", commandList);

                commandcount += commandList.Count;
                helpBuilder.AddField(e.ToString(), commandString);
            }

            helpBuilder.WithFooter($"Loaded {commandcount} commands");
            await channel.SendMessageAsync("", false, helpBuilder.Build());
        }

        public async Task HelpCommandAsync(ISocketMessageChannel channel, string command)
        {
            var commandInfo = Program.CommandService.Commands.FirstOrDefault(x =>
                x.Aliases.Contains(command, StringComparer.CurrentCultureIgnoreCase));
            if (commandInfo == default(CommandInfo))
            {
                channel.SendMessageAsync("", false, EmbedService.ErrorBuilder("Command not found"));
                return;
            }

            var helpBuilder = new EmbedBuilder();
            helpBuilder.WithTitle($":information_source: {commandInfo.Name} command help")
                .WithColor(Color.Blue);

            if (commandInfo.Summary != null) helpBuilder.WithDescription(commandInfo.Summary);

            helpBuilder.AddField("Usage", await Util.GetUsage(commandInfo));

            var categoryattribute = commandInfo.Attributes.OfType<CommandCategoryAttribute>();
            if (categoryattribute.Any()) helpBuilder.AddField("Category", categoryattribute.First().Category);

            if (commandInfo.Aliases.Any())
            {
                var aliases = string.Join(", ", commandInfo.Aliases);
                helpBuilder.AddField("Aliases", aliases);
            }

            channel.SendMessageAsync("", false, helpBuilder.Build());
        }
    }
}
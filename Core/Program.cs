#region

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.Services.Settings;
using DiscordBOT.Services;
using DiscordBOT.Services.Administration;
using DiscordBOT.Services.External;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace DiscordBOT.Core
{
    internal class Program
    {
        public static DiscordSocketClient Client;
        public static CommandService CommandService;
        public static IServiceProvider ServiceProvider;

        public static void Main(string[] args)
        {
            new Program().RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {
            await new Variables().UpdateVariables();

            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                DefaultRetryMode = RetryMode.AlwaysRetry,
                MessageCacheSize = 10000
            });
            CommandService = new CommandService(new CommandServiceConfig
            {
                DefaultRunMode = RunMode.Async,
                ThrowOnError = false,
                IgnoreExtraArgs = true
            });
            ServiceProvider = new ServiceCollection()
                .AddSingleton(Client)
                .AddSingleton(CommandService)
                .BuildServiceProvider();

            Client.MessageReceived += HandleCommandAsync;
            Client.Log += LogAsync;
            Client.UserJoined += AnnounceUserJoinedAsync;
            Client.UserLeft += AnnounceUserLeftAsync;
            Client.Ready += OnReadyAsync;
            Client.ChannelCreated += MuteService.AddPermissionOverwriteAsync;

            await CommandService.AddModulesAsync(Assembly.GetEntryAssembly());

            await Client.LoginAsync(TokenType.Bot, Variables.BotToken);
            await Client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task OnReadyAsync()
        {
            await Client.SetGameAsync(
                $"for commands | {Variables.BotPrefix}help",
                "https://www.twitch.tv/twitch",
                ActivityType.Watching);
            foreach (var guild in Client.Guilds) Console.WriteLine($"ONGUILD: {guild.Name}");
        }

        private async Task AnnounceUserJoinedAsync(SocketGuildUser user)
        {
            var channelId = await WelcomeChannelService.GetWelcomeChannelId(user.Guild);
            if (channelId != default(ulong))
            {
                var channel = user.Guild.GetTextChannel(channelId);
                var message =
                    await Util.ConvertToMessage(user, await ServerAnnounceService.GetWelcomeMessage(user.Guild));
                await channel.SendMessageAsync(message);
                var everyonerole = user.Guild.GetRole(await EveryoneRoleService.GetEveryoneRoleAsync(user.Guild));
                await user.AddRoleAsync(everyonerole);
            }
        }

        private async Task AnnounceUserLeftAsync(SocketGuildUser user)
        {
            var channelId = await WelcomeChannelService.GetWelcomeChannelId(user.Guild);
            if (channelId != default(ulong))
            {
                var channel = user.Guild.GetTextChannel(channelId);
                var message =
                    await Util.ConvertToMessage(user, await ServerAnnounceService.GetLeaveMessage(user.Guild));
                await channel.SendMessageAsync(message);
            }
        }

        public async Task DeletedLog(Cacheable<IMessage, ulong> message, ISocketMessageChannel channel)
        {
            var guild = ((await message.GetOrDownloadAsync()).Channel as SocketTextChannel).Guild;
            var channelId = await ServerLogChannelService.GetLogChannelId(guild);
            if (channelId != default(ulong))
            {
                var deletedmessage = await message.GetOrDownloadAsync();
                var logchannel = guild.GetTextChannel(await ServerLogChannelService.GetLogChannelId(guild));
                var deletedmessagecontent = deletedmessage.Content == ""
                    ? deletedmessage.Embeds.First().Description
                    : deletedmessage.Content;
                logchannel.SendMessageAsync("", false,
                    EmbedService.LogBuilder("Message deleted",
                        $"{deletedmessage.Author.Username} deleted the message '{deletedmessagecontent}' in {deletedmessage.Channel.Name}"));
            }
        }

        public static async Task LogAsync(LogMessage message)
        {
            switch (message.Severity)
            {
                case LogSeverity.Critical:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Verbose:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine(message.Severity.ToString().ToUpper() + ": " + message.Message == ""
                ? message.Exception.Message
                : message.Message);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            if (!(arg is SocketUserMessage message) || arg.Author.IsBot ||
                !(message.Channel is SocketGuildChannel)) return;

            var context = new SocketCommandContext(Client, message);

            AfkService.CheckAfkAsync(context.Guild.GetUser(context.User.Id), context.Channel);
            LevelService.IncreaseXp(context.User as SocketGuildUser, context.Guild.GetTextChannel(context.Channel.Id),
                context.Guild);

            var argPos = 0;
            
            if (message.HasMentionPrefix(Client.CurrentUser, ref argPos) || message.HasStringPrefix(
                    await ServerPrefixService.GetServerPrefix(context.Guild),
                    ref argPos, StringComparison.CurrentCultureIgnoreCase) ||
                message.HasStringPrefix(Variables.BotPrefix, ref argPos,
                    StringComparison.CurrentCultureIgnoreCase) &&
                !(await DatabaseService.GetBlacklistedChannelIDs(context.Guild.Id)).Contains(context.Channel.Id))
                using (context.Channel.EnterTypingState())
                {
                    var result = await CommandService.ExecuteAsync(context, argPos, ServiceProvider);

                    if (!result.IsSuccess)
                        switch (result.Error.Value)
                        {
                            case CommandError.BadArgCount:
                                var commandInfo = await Util.GetCommandInfo(context, argPos);
                                var usage = await Util.GetUsage(commandInfo);
                                message.Channel.SendMessageAsync("", false,
                                    EmbedService.InfoBuilder($"Usage {commandInfo.Name}", usage));
                                break;
                            case CommandError.UnknownCommand:
                                message.Channel.SendMessageAsync("", false,
                                    EmbedService.ErrorBuilder("Unknown command"));
                                break;
                            case CommandError.UnmetPrecondition when result.ErrorReason == "This channel is not nsfw" ||
                                                                     result.ErrorReason ==
                                                                     "Nsfw is not enabled on this server":
                                message.Channel.SendMessageAsync("", false,
                                    EmbedService.ErrorBuilder(result.ErrorReason));
                                break;
                            case CommandError.UnmetPrecondition:
                                message.Channel.SendMessageAsync("", false,
                                    EmbedService.ErrorBuilder(
                                        $"You or {Client.CurrentUser.Username} have not enough permissions"));
                                break;
                            case CommandError.Exception:
                                message.Channel.SendMessageAsync("", false,
                                    EmbedService.ErrorBuilder("Couldn't execute command, try again later"));
                                break;
                            default:
                                message.Channel.SendMessageAsync("", false,
                                    EmbedService.ErrorBuilder($"REASON: {result.ErrorReason}"));
                                break;
                        }
                }
        }
    }
}
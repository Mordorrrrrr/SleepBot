#region

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;
using DiscordBOT.Services.External;

#endregion

namespace DiscordBOT.Services.Music
{
    public static class MusicService
    {
        public static async Task JoinAsync(SocketTextChannel channel,
            SocketGuildUser user)
        {
            if (user.Guild.AudioClient.ConnectionState == ConnectionState.Connected &&
                user.Guild.Owner != user)
            {
                await channel.SendMessageAsync("", false,
                    EmbedService.ErrorBuilder("The bot is already in a channel"));
            }
            else
            {
                if (!user.VoiceState.HasValue)
                {
                    await channel.SendMessageAsync("", false,
                        EmbedService
                            .ErrorBuilder("You have to be in a voice channel to use this command"));
                }
                else
                {
                    await user.Guild.GetVoiceChannel(user.VoiceChannel.Id).ConnectAsync();
                    await channel.SendMessageAsync("", false,
                        EmbedService.SuccesBuilder("Successfully joined your channel"));
                }
            }
        }

        public static async Task DisconnectAsync(SocketGuild guild, SocketTextChannel channel,
            SocketVoiceChannel voiceChannel, SocketGuildUser user)
        {
            if (guild.AudioClient == default(IAudioClient)) await voiceChannel.ConnectAsync();
            if (guild.AudioClient.ConnectionState == ConnectionState.Connected)
            {
                if (guild.GetUser(Program.Client.CurrentUser.Id).VoiceChannel.Users.Contains(user) ||
                    guild.Owner == user)
                {
                    await guild.AudioClient.StopAsync();
                    await channel.SendMessageAsync("", false,
                        EmbedService.SuccesBuilder("Bot disconnected successfully"));
                }
                else
                {
                    await channel.SendMessageAsync("", false,
                        EmbedService.ErrorBuilder(
                            $"You are not in the same channel as {Program.Client.CurrentUser.Username}"));
                }
            }
            else
            {
                await channel.SendMessageAsync("", false, EmbedService.ErrorBuilder("The bot is in no channel"));
            }
        }

        public static async Task PlayAsync(SocketCommandContext context, string url)
        {
            var path = new YtService().GetAudioUrl(url);

            using (var ffmpeg = await CreateProcess(path))
            {
                using (var stream = context.Guild.AudioClient.CreatePCMStream(AudioApplication.Music))
                {
                    try
                    {
                        await ffmpeg.StandardOutput.BaseStream.CopyToAsync(stream);
                    }
                    finally
                    {
                        await stream.FlushAsync().ConfigureAwait(true);
                    }
                }
            }
        }

        public static async Task<Process> CreateProcess(string path)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg.exe",
                Arguments = $"-hide_banner -loglevel panic -i \"{path}\" -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true
            });
        }
    }
}
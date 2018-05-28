#region

using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using MediaToolkit;
using MediaToolkit.Model;
using VideoLibrary;

#endregion

namespace DiscordBOT.Services.External
{
    public class YtService
    {
        public static async Task<string> GetYtVideoByUrl(string url)
        {
            var youtube = YouTube.Default;
            var video = await youtube.GetVideoAsync(url);
            if (File.Exists(video.FullName + ".mp3")) return video.FullName + ".mp3";
            File.WriteAllBytes(video.FullName, video.GetBytes());

            var input = new MediaFile {Filename = video.FullName};
            var output = new MediaFile
            {
                Filename = video.FullName + ".mp3"
            };

            using (var engine = new Engine())
            {
                engine.GetMetadata(input);

                engine.Convert(input, output);
            }

            return output.Filename;
        }

        public string GetAudioUrl(string url)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = @"music/youtube-dl.exe",
                Arguments = $" -x -g \"{url}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true
            }).StandardOutput.ReadLine();
        }
    }
}
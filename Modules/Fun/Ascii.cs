#region

using System.Net.Http;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT.Modules.Fun
{
    public class Ascii : ModuleBase<SocketCommandContext>
    {
        [Command("ascii", RunMode = RunMode.Async)]
        [CommandCategory(Category = CommandCategory.Fun)]
        [Summary("Converts a text to an ASCII text")]
        public async Task AsciiAsync([Remainder] string text)
        {
            text = text.Replace(" ", "+");
            await ReplyAsync(
                $"```\n{await new HttpClient().GetStringAsync($"http://artii.herokuapp.com/make?text={text}")}\n```");
        }
    }
}
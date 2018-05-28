#region

using System.Threading.Tasks;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Services.Tools.QrCode;

#endregion

namespace DiscordBOT.Modules.Tools
{
    public class Qr : ModuleBase<SocketCommandContext>
    {
        [Command("qr")]
        [CommandCategory(Category = CommandCategory.Tools)]
        [Summary("Generates a QR code")]
        public async Task EncodeAsync([Remainder] string text)
        {
            await QrCodeService.SendQrCodeAsync(text, Context.Channel);
        }
    }
}
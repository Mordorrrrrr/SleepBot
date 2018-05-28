#region

using System;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using Discord;
using Discord.Commands;
using DiscordBOT.Core;
using DiscordBOT.Modules.Administration;
using DiscordBOT.Services;

#endregion

namespace DiscordBOT.Modules.Moderation
{
    public class Bulk : ModuleBase<SocketCommandContext>
    {
        [Command("bulk", RunMode = RunMode.Async)]
        [Alias("bulkdelete", "blk")]
        [CommandCategory(Category = CommandCategory.Moderation)]
        [Summary("Clears the complete chat")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task BulkAsync()
        {
            var channel = Context.Guild.GetTextChannel(Context.Channel.Id);
            await Context.Guild.GetTextChannel(Context.Channel.Id).DeleteAsync();
            var newchannel = await Context.Guild.CreateTextChannelAsync(channel.Name);
            await newchannel.ModifyAsync(x =>
            {
                x.IsNsfw = channel.IsNsfw;
                x.CategoryId = channel.CategoryId;
                x.Position = channel.Position;
                x.Topic = channel.Topic;
            });
            foreach (var permissionOverwrite in channel.PermissionOverwrites)
                switch (permissionOverwrite.TargetType)
                {
                    case PermissionTarget.Role:
                        var role = Context.Guild.GetRole(permissionOverwrite.TargetId);
                        await newchannel.AddPermissionOverwriteAsync(role, permissionOverwrite.Permissions);
                        break;
                    case PermissionTarget.User:
                        var user = Context.Guild.GetUser(permissionOverwrite.TargetId);
                        await newchannel.AddPermissionOverwriteAsync(user, permissionOverwrite.Permissions);
                        break;
                }

            var message = await newchannel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder("Successfully deleted all messages"));
            await LogService.SendLogMessageAsync(Context.Guild, "", false,
                EmbedService.LogBuilder("Bulk delete",
                    $"{Context.User.Mention} used bulk delete in {newchannel.Mention}"));
            await Task.Delay(TimeSpan.FromSeconds(15));
            await message.DeleteAsync();
        }
    }
}
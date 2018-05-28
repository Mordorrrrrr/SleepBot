#region

using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBOT.Services.Administration;

#endregion

namespace DiscordBOT.Services.External
{
    public static class LevelService
    {
        public static async Task IncreaseXp(SocketGuildUser user, ISocketMessageChannel channel, SocketGuild guild,
            ulong xp = 0)
        {
            try
            {
                if (xp == 0) xp = (ulong) new Random().Next(15, 25);

                var oldlevel = await GetLevel(user);

                await DatabaseService.IncreaseUserXP(user.Id, xp);

                var newlevel = await GetLevel(user);

                if (newlevel > oldlevel)
                    await channel.SendMessageAsync(await Util.ConvertToMessage(user,
                        await DatabaseService.GetLevelUpMessage(guild.Id),
                        newlevel));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static async Task<ulong> GetLevel(SocketGuildUser user)
        {
            var level = await DatabaseService.GetUserLevel(user.Id);
            return level;
        }

        public static async Task<ulong> GetXP(SocketUser user)
        {
            var level = await DatabaseService.GetUserXP(user.Id);
            return level;
        }

        public static async Task SetLevelUpMessage(SocketGuild guild, string message, SocketTextChannel channel)
        {
            DatabaseService.SetLevelUpMessage(guild.Id, message);

            channel.SendMessageAsync("", false,
                EmbedService.SuccesBuilder($"Successfully set the server's levelupmessage to '{message}'"));
        }

        public static async Task<string> GetLevelUpMessage(SocketGuild guild)
        {
            return await DatabaseService.GetLevelUpMessage(guild.Id);
        }

        public static async Task<double> GetNeededXP(SocketUser user)
        {
            var needed = (double) 1000 * (double) await DatabaseService.GetUserLevel(user.Id) / (double) 2;
            return needed;
        }
    }
}
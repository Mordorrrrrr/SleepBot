#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Modules.Administration;

#endregion

namespace DiscordBOT.Core
{
    public class CommandCategoryAttribute : Attribute
    {
        public CommandCategory Category;
    }

    public enum CommandCategory
    {
        General,
        Administration,
        Moderation,
        Music,
        Settings,
        Tools,
        NSFW,
        Fun
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CheckNsfw : PreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command,
            IServiceProvider prov)
        {
            if (!context.Guild.GetTextChannelAsync(context.Channel.Id).GetAwaiter().GetResult().IsNsfw)
                return Task.FromResult(PreconditionResult.FromError($"This channel is not nsfw"));
            if (!NsfwService.GetNsfw(context.Guild as SocketGuild).GetAwaiter().GetResult())
                return Task.FromResult(PreconditionResult.FromError($"Nsfw is not enabled on this server"));

            return Task.FromResult(PreconditionResult.FromSuccess());
        }
    }

    public static class RomanNumberService
    {
        private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public static int RomanToInteger(string roman)
        {
            var number = 0;
            for (var i = 0; i < roman.Length; i++)
                if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                    number -= RomanMap[roman[i]];
                else
                    number += RomanMap[roman[i]];
            return number;
        }
    }
}
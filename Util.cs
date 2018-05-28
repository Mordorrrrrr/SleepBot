#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBOT.Core;

#endregion

namespace DiscordBOT
{
    public class Util
    {
        public static async Task<string> GetUsage(CommandInfo commandInfo)
        {
            var parameters = "";
            foreach (var p in commandInfo.Parameters)
                if (!p.IsOptional)
                    parameters += "<" + p.Name + "> ";
                else
                    parameters += "(" + p.Name + ") ";

            var usage = Variables.BotPrefix + commandInfo.Name;
            if (parameters != "") usage += " " + parameters;

            return usage;
        }

        public static async Task<CommandInfo> GetCommandInfo(SocketCommandContext context, int argPos = 0)
        {
            return Program.CommandService.Commands.FirstOrDefault(x =>
                x.Aliases.Contains(Program.CommandService.Search(context, argPos).Commands.FirstOrDefault().Alias));
        }

        public static async Task<string> GetDate(DateTime dateTime)
        {
            return
                $"{dateTime.Day}.{dateTime.Month}.{dateTime.Year} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
        }

        public static async Task<string> GetTimePeriod(TimeSpan dateTime)
        {
            return $"{dateTime.Days}d, {dateTime.Hours}h, {dateTime.Minutes}min, {dateTime.Seconds}s";
        }

        public static async Task<string> ConvertToMessage(SocketGuildUser user, string message,
            ulong? level = null)
        {
            var list = new Dictionary<string, string>
            {
                {"%mention%", user.Mention},
                {"%user%", user.Nickname ?? user.Username},
                {"%server%", user.Guild.Name}
            };

            foreach (var r in list) message = message.Replace(r.Key, r.Value);
            if (level != null) message = message.Replace("%level%", level.ToString());

            return message;
        }
    }
}
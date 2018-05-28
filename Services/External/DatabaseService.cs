#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DiscordBOT.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

#endregion

namespace DiscordBOT.Services.Administration
{
    public static class DatabaseService
    {
        public static async Task<string> GetServerPrefix(ulong serverid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Servers.Find(serverid) == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid
                    };
                    db.Servers.Add(s);
                    db.SaveChangesAsync();
                }


                var server = db.Servers.Find(serverid).ServerPrefix;
                return server == "" ? Variables.BotPrefix : server;
            }
        }

        public static async Task SetServerPrefix(ulong serverid, string prefix)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        ServerPrefix = prefix
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.ServerPrefix = prefix;
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }
        
        public static async Task<ulong> GetEveryoneRoleID(ulong serverid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Servers.Find(serverid) == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid
                    };
                    db.Servers.Add(s);
                    db.SaveChangesAsync();
                }


                var id = db.Servers.Find(serverid).EveryoneRoleID;
                return id;
            }
        }

        public static async Task SetEveryoneRoleID(ulong serverid, ulong id)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        EveryoneRoleID = id
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.EveryoneRoleID = id;
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task<ulong> GetWelcomeChannelId(ulong serverid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Servers.Find(serverid) == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid
                    };
                    db.Servers.Add(s);
                    db.SaveChangesAsync();
                }


                var server = db.Servers.Find(serverid).WelcomeChannelID;
                return server;
            }
        }

        public static async Task SetWelcomeChannelId(ulong serverid, ulong channelid)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        WelcomeChannelID = channelid
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.WelcomeChannelID = channelid;
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task<ulong> GetLogChannelId(ulong serverid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Servers.Find(serverid) == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid
                    };
                    db.Servers.Add(s);
                    db.SaveChangesAsync();
                }


                var server = db.Servers.Find(serverid).LogChannelID;
                return server;
            }
        }

        public static async Task SetLogChannelId(ulong serverid, ulong channelid)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        LogChannelID = channelid
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.LogChannelID = channelid;
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task<string> GetWelcomeMessage(ulong serverid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Servers.Find(serverid) == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid
                    };
                    db.Servers.Add(s);
                    db.SaveChangesAsync();
                }


                var server = db.Servers.Find(serverid).WelcomeMessage;
                return server == "" ? Variables.DefaultUserJoined : server;
            }
        }

        public static async Task SetWelcomeMessage(ulong serverid, string message)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        WelcomeMessage = message
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.WelcomeMessage = message;
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task<string> GetLeaveMessage(ulong serverid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Servers.Find(serverid) == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid
                    };
                    db.Servers.Add(s);
                    db.SaveChangesAsync();
                }


                var server = db.Servers.Find(serverid).LeaveMessage;
                return server == "" ? Variables.DefaultUserLeft : server;
            }
        }

        public static async Task SetLeaveMessage(ulong serverid, string message)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        LeaveMessage = message
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.LeaveMessage = message;
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task<string> GetLevelUpMessage(ulong serverid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Servers.Find(serverid) == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid
                    };
                    db.Servers.Add(s);
                    db.SaveChangesAsync();
                }


                var message = db.Servers.Find(serverid).LevelUpMessage;
                return message == "" ? Variables.DefaultLevelUpMessage : message;
            }
        }

        public static async Task<bool> GetNsfwEnabled(ulong serverid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Servers.Find(serverid) == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid
                    };
                    db.Servers.Add(s);
                    db.SaveChangesAsync();
                }


                var state = db.Servers.Find(serverid).NsfwEnabled;
                return state;
            }
        }

        public static async Task SetNsfwEnabled(ulong serverid, bool state)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        NsfwEnabled = state
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.NsfwEnabled = state;
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task SetLevelUpMessage(ulong serverid, string message)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        LevelUpMessage = message
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.LevelUpMessage = message;
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task<List<ulong>> GetBlacklistedChannelIDs(ulong serverid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Servers.Find(serverid) == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid
                    };
                    db.Servers.Add(s);
                    db.SaveChangesAsync();
                }


                var channelids = new List<ulong>();
                try
                {
                    channelids = db.Servers.Find(serverid).BlacklistedChannelIDs.Split(',').Select(ulong.Parse)
                        .ToList();
                }
                catch (Exception e)
                {
                    channelids = new List<ulong>();
                }

                return channelids;
            }
        }

        public static async Task SetBlacklistedChannelIDs(ulong serverid, IEnumerable<ulong> channelids)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        BlacklistedChannelIDs = string.Join(",", channelids)
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.BlacklistedChannelIDs = string.Join(",", channelids);
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task ClearBlacklistedChannelIDs(ulong serverid)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.BlacklistedChannelIDs = "";
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task AddToBlacklistedChannelIDs(ulong serverid, IEnumerable<ulong> channelids)
        {
            using (var db = new SleepBotContext())
            {
                var bcid = new List<ulong>();
                try
                {
                    bcid = await GetBlacklistedChannelIDs(serverid) ?? new List<ulong>();
                }
                catch (Exception e)
                {
                    bcid = new List<ulong>();
                }

                foreach (var channelid in channelids) bcid.Remove(channelid);

                bcid.AddRange(channelids);

                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        BlacklistedChannelIDs = string.Join(",", bcid)
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.BlacklistedChannelIDs = string.Join(",", bcid);
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task RemoveFromBlacklistedChannelIDs(ulong serverid, IEnumerable<ulong> channelids)
        {
            using (var db = new SleepBotContext())
            {
                var bcid = new List<ulong>();
                try
                {
                    bcid = await GetBlacklistedChannelIDs(serverid) ?? new List<ulong>();
                }
                catch (Exception e)
                {
                    bcid = new List<ulong>();
                }

                foreach (var channelid in channelids) bcid.Remove(channelid);

                var data = db.Servers.Find(serverid);
                if (data == null)
                {
                    var s = new Server
                    {
                        ServerID = serverid,
                        BlacklistedChannelIDs = string.Join(",", bcid)
                    };
                    db.Servers.Add(s);
                }
                else
                {
                    data.BlacklistedChannelIDs = string.Join(",", bcid);
                    db.Servers.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task<ulong> GetUserLevel(ulong userid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Userxp.Find(userid) == null) return 0;

                var level = db.Userxp.Find(userid).UserLevel;
                return level;
            }
        }

        public static async Task SetUserLevel(ulong userid, ulong level)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Userxp.Find(userid);
                if (data == null)
                {
                    var u = new Userxp
                    {
                        UserID = userid,
                        UserLevel = level
                    };
                    db.Userxp.Add(u);
                }
                else
                {
                    data.UserLevel = level;
                    db.Userxp.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task IncreaseUserLevel(ulong userid, ulong level)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Userxp.Find(userid);
                if (data == null)
                {
                    var u = new Userxp
                    {
                        UserID = userid,
                        UserLevel = level
                    };
                    db.Userxp.Add(u);
                }
                else
                {
                    data.UserLevel = data.UserLevel + level;
                    db.Userxp.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task<ulong> GetUserXP(ulong userid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Userxp.Find(userid) == null)
                {
                    var u = new Userxp
                    {
                        UserID = userid
                    };
                    db.Userxp.Add(u);
                    db.SaveChangesAsync();
                }


                var xp = db.Userxp.Find(userid).UserXP;
                return xp;
            }
        }

        public static async Task SetUserXP(ulong userid, ulong xp)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Userxp.Find(userid);
                if (data == null)
                {
                    var u = new Userxp
                    {
                        UserID = userid,
                        UserXP = xp
                    };
                    db.Userxp.Add(u);
                }
                else
                {
                    data.UserXP = xp;
                    db.Userxp.Update(data);
                }

                db.SaveChangesAsync();
            }
        }

        public static async Task IncreaseUserXP(ulong userid, ulong xp)
        {
            using (var db = new SleepBotContext())
            {
                var data = db.Userxp.Find(userid);
                if (data == null)
                {
                    var u = new Userxp
                    {
                        UserID = userid,
                        UserXP = xp
                    };
                    db.Userxp.Add(u);
                }
                else
                {
                    data.UserXP = data.UserXP + xp;
                    db.Userxp.Update(data);
                }

                await db.SaveChangesAsync();

                var upperxp = 1000 * await GetUserLevel(userid) / 2;
                if (upperxp <= data.UserXP)
                {
                    await IncreaseUserLevel(userid, 1);
                    data.UserXP = data.UserXP - upperxp;
                }

                await db.SaveChangesAsync();
            }
        }

        public static async Task<string> GetUserWans(ulong serverid, ulong userid)
        {
            using (var db = new SleepBotContext())
            {
                if (db.Userwarns.Find(serverid) == null)
                {
                    var u = new Userwarns
                    {
                        ServerID = serverid,
                        UserID = userid
                    };
                    db.Userwarns.Add(u);
                    db.SaveChangesAsync();
                }


                var warns = db.Userwarns.Find(userid).Warns;
                return warns;
            }
        }
    }
}


public class Server
{
    public Server()
    {
        ServerID = 0;
        ServerPrefix = "";
        WelcomeChannelID = 0;
        LogChannelID = 0;
        WelcomeMessage = "";
        LeaveMessage = "";
        LevelUpMessage = "";
        NsfwEnabled = true;
        BlacklistedChannelIDs = "";
    }

    [Key] public ulong ServerID { get; set; }

    public string ServerPrefix { get; set; }
    public ulong EveryoneRoleID { get; set; }
    public ulong WelcomeChannelID { get; set; }
    public ulong LogChannelID { get; set; }
    public string WelcomeMessage { get; set; }
    public string LeaveMessage { get; set; }
    public string LevelUpMessage { get; set; }
    public bool NsfwEnabled { get; set; }
    public string BlacklistedChannelIDs { get; set; }
}

public class Userwarns
{
    [Key] public ulong ServerID { get; set; }
    public ulong UserID { get; set; }
    public string Warns { get; set; }
    
    public Userwarns()
    {
        ServerID = 0;
        UserID = 0;
        Warns = "";
    }
}

public class Userxp
{
    public Userxp()
    {
        UserID = 0;
        UserLevel = 0;
        UserXP = 0;
    }

    [Key] public ulong UserID { get; set; }

    public ulong UserLevel { get; set; }
    public ulong UserXP { get; set; }
}

public class SleepBotContext : DbContext
{
    public DbSet<Server> Servers { get; set; }
    public DbSet<Userwarns> Userwarns { get; set; }
    public DbSet<Userxp> Userxp { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server = localhost; User = root; Database = sleepbot; Password = ;");
    }
}
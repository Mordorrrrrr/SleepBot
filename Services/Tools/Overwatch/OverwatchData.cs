#region

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace OverwatchData
{
    public partial class OverwatchData
    {
        [JsonProperty("icon")] public string Icon { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("level")] public long Level { get; set; }

        [JsonProperty("levelIcon")] public string LevelIcon { get; set; }

        [JsonProperty("prestige")] public long Prestige { get; set; }

        [JsonProperty("prestigeIcon")] public string PrestigeIcon { get; set; }

        [JsonProperty("rating")] public string Rating { get; set; }

        [JsonProperty("ratingIcon")] public string RatingIcon { get; set; }

        [JsonProperty("ratingName")] public string RatingName { get; set; }

        [JsonProperty("gamesWon")] public long GamesWon { get; set; }

        [JsonProperty("quickPlayStats")] public QuickPlayStats QuickPlayStats { get; set; }

        [JsonProperty("competitiveStats")] public CompetitiveStats CompetitiveStats { get; set; }
    }

    public class CompetitiveStats
    {
        [JsonProperty("eliminationsAvg")] public long EliminationsAvg { get; set; }

        [JsonProperty("damageDoneAvg")] public long DamageDoneAvg { get; set; }

        [JsonProperty("deathsAvg")] public long DeathsAvg { get; set; }

        [JsonProperty("finalBlowsAvg")] public long FinalBlowsAvg { get; set; }

        [JsonProperty("healingDoneAvg")] public long HealingDoneAvg { get; set; }

        [JsonProperty("objectiveKillsAvg")] public long ObjectiveKillsAvg { get; set; }

        [JsonProperty("objectiveTimeAvg")] public string ObjectiveTimeAvg { get; set; }

        [JsonProperty("soloKillsAvg")] public long SoloKillsAvg { get; set; }

        [JsonProperty("games")] public Games Games { get; set; }

        [JsonProperty("awards")] public Awards Awards { get; set; }

        [JsonProperty("topHeroes")] public TopHeroes TopHeroes { get; set; }

        [JsonProperty("careerStats")] public CompetitiveStatsCareerStats CareerStats { get; set; }
    }

    public class Awards
    {
        [JsonProperty("cards", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cards { get; set; }

        [JsonProperty("medals")] public long Medals { get; set; }

        [JsonProperty("medalsBronze", NullValueHandling = NullValueHandling.Ignore)]
        public long? MedalsBronze { get; set; }

        [JsonProperty("medalsSilver", NullValueHandling = NullValueHandling.Ignore)]
        public long? MedalsSilver { get; set; }

        [JsonProperty("medalsGold", NullValueHandling = NullValueHandling.Ignore)]
        public long? MedalsGold { get; set; }
    }

    public class CompetitiveStatsCareerStats
    {
        [JsonProperty("allHeroes")] public PurpleAllHeroes AllHeroes { get; set; }

        [JsonProperty("ana")] public PurpleAna Ana { get; set; }

        [JsonProperty("bastion")] public PurpleBastion Bastion { get; set; }

        [JsonProperty("brigitte")] public PurpleBrigitte Brigitte { get; set; }

        [JsonProperty("junkrat")] public PurpleJunkrat Junkrat { get; set; }

        [JsonProperty("lucio")] public PurpleLucio Lucio { get; set; }

        [JsonProperty("mccree")] public PurpleMccree Mccree { get; set; }

        [JsonProperty("mei")] public PurpleMei Mei { get; set; }

        [JsonProperty("mercy")] public PurpleMercy Mercy { get; set; }

        [JsonProperty("moira")] public PurpleMoira Moira { get; set; }

        [JsonProperty("pharah")] public PurplePharah Pharah { get; set; }

        [JsonProperty("reaper")] public PurpleReaper Reaper { get; set; }

        [JsonProperty("reinhardt")] public PurpleReinhardt Reinhardt { get; set; }

        [JsonProperty("roadhog")] public PurpleRoadhog Roadhog { get; set; }

        [JsonProperty("soldier76")] public PurpleSoldier76 Soldier76 { get; set; }

        [JsonProperty("winston")] public PurpleWinston Winston { get; set; }

        [JsonProperty("zarya")] public PurpleZarya Zarya { get; set; }

        [JsonProperty("zenyatta")] public PurpleZenyatta Zenyatta { get; set; }
    }

    public class PurpleAllHeroes
    {
        [JsonProperty("assists")] public BrigitteAssists Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public AllHeroesBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public HeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public PurpleMiscellaneous Miscellaneous { get; set; }
    }

    public class BrigitteAssists
    {
        [JsonProperty("defensiveAssists")] public long DefensiveAssists { get; set; }

        [JsonProperty("healingDone")] public long HealingDone { get; set; }

        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }
    }

    public class AllHeroesAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("criticalHits", NullValueHandling = NullValueHandling.Ignore)]
        public long? CriticalHits { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("deathsBlossomKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeathsBlossomKills { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("eliminationsPerLife", NullValueHandling = NullValueHandling.Ignore)]
        public double? EliminationsPerLife { get; set; }

        [JsonProperty("finalBlows")] public long FinalBlows { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("meleeFinalBlows", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeleeFinalBlows { get; set; }

        [JsonProperty("objectiveKills")] public long ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("selfHealing", NullValueHandling = NullValueHandling.Ignore)]
        public long? SelfHealing { get; set; }

        [JsonProperty("soloKills")] public long SoloKills { get; set; }

        [JsonProperty("timeSpentOnFire")] public long TimeSpentOnFire { get; set; }

        [JsonProperty("barrageKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? BarrageKills { get; set; }

        [JsonProperty("rocketDirectHits", NullValueHandling = NullValueHandling.Ignore)]
        public long? RocketDirectHits { get; set; }

        [JsonProperty("enemiesHooked", NullValueHandling = NullValueHandling.Ignore)]
        public long? EnemiesHooked { get; set; }

        [JsonProperty("hookAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public string HookAccuracy { get; set; }

        [JsonProperty("offensiveAssists", NullValueHandling = NullValueHandling.Ignore)]
        public long? OffensiveAssists { get; set; }

        [JsonProperty("wholeHogKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? WholeHogKills { get; set; }

        [JsonProperty("healingDone", NullValueHandling = NullValueHandling.Ignore)]
        public long? HealingDone { get; set; }

        [JsonProperty("defensiveAssists", NullValueHandling = NullValueHandling.Ignore)]
        public long? DefensiveAssists { get; set; }

        [JsonProperty("helixRocketsKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? HelixRocketsKills { get; set; }

        [JsonProperty("tacticalVisorKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? TacticalVisorKills { get; set; }

        [JsonProperty("enemiesEmpd", NullValueHandling = NullValueHandling.Ignore)]
        public long? EnemiesEmpd { get; set; }

        [JsonProperty("enemiesHacked", NullValueHandling = NullValueHandling.Ignore)]
        public long? EnemiesHacked { get; set; }

        [JsonProperty("armorPacksCreated", NullValueHandling = NullValueHandling.Ignore)]
        public long? ArmorPacksCreated { get; set; }

        [JsonProperty("moltenCoreKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? MoltenCoreKills { get; set; }

        [JsonProperty("torbjornKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? TorbjornKills { get; set; }

        [JsonProperty("turretsKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? TurretsKills { get; set; }

        [JsonProperty("healthRecovered", NullValueHandling = NullValueHandling.Ignore)]
        public long? HealthRecovered { get; set; }

        [JsonProperty("pulseBombsAttached", NullValueHandling = NullValueHandling.Ignore)]
        public long? PulseBombsAttached { get; set; }

        [JsonProperty("pulseBombsKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? PulseBombsKills { get; set; }

        [JsonProperty("reconAssists", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReconAssists { get; set; }

        [JsonProperty("scopedAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public string ScopedAccuracy { get; set; }

        [JsonProperty("scopedCriticalHits", NullValueHandling = NullValueHandling.Ignore)]
        public long? ScopedCriticalHits { get; set; }

        [JsonProperty("venomMineKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? VenomMineKills { get; set; }
    }

    public class AllHeroesBest
    {
        [JsonProperty("allDamageDoneMostInGame")]
        public long AllDamageDoneMostInGame { get; set; }

        [JsonProperty("barrierDamageDoneMostInGame")]
        public long BarrierDamageDoneMostInGame { get; set; }

        [JsonProperty("defensiveAssistsMostInGame")]
        public long DefensiveAssistsMostInGame { get; set; }

        [JsonProperty("eliminationsMostInGame")]
        public long EliminationsMostInGame { get; set; }

        [JsonProperty("environmentalKillsMostInGame")]
        public long EnvironmentalKillsMostInGame { get; set; }

        [JsonProperty("finalBlowsMostInGame")] public long FinalBlowsMostInGame { get; set; }

        [JsonProperty("healingDoneMostInGame")]
        public long HealingDoneMostInGame { get; set; }

        [JsonProperty("heroDamageDoneMostInGame")]
        public long HeroDamageDoneMostInGame { get; set; }

        [JsonProperty("killsStreakBest")] public long KillsStreakBest { get; set; }

        [JsonProperty("meleeFinalBlowsMostInGame")]
        public long MeleeFinalBlowsMostInGame { get; set; }

        [JsonProperty("multikillsBest")] public long MultikillsBest { get; set; }

        [JsonProperty("objectiveKillsMostInGame")]
        public long ObjectiveKillsMostInGame { get; set; }

        [JsonProperty("objectiveTimeMostInGame")]
        public string ObjectiveTimeMostInGame { get; set; }

        [JsonProperty("offensiveAssistsMostInGame")]
        public long OffensiveAssistsMostInGame { get; set; }

        [JsonProperty("soloKillsMostInGame")] public long SoloKillsMostInGame { get; set; }

        [JsonProperty("timeSpentOnFireMostInGame")]
        public string TimeSpentOnFireMostInGame { get; set; }

        [JsonProperty("turretsDestroyedMostInGame")]
        public long TurretsDestroyedMostInGame { get; set; }

        [JsonProperty("reconAssistsMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReconAssistsMostInGame { get; set; }

        [JsonProperty("shieldGeneratorsDestroyedMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShieldGeneratorsDestroyedMostInGame { get; set; }

        [JsonProperty("teleporterPadsDestroyedMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? TeleporterPadsDestroyedMostInGame { get; set; }
    }

    public class PurpleCombat
    {
        [JsonProperty("barrierDamageDone", NullValueHandling = NullValueHandling.Ignore)]
        public long? BarrierDamageDone { get; set; }

        [JsonProperty("damageDone")] public long DamageDone { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("environmentalKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? EnvironmentalKills { get; set; }

        [JsonProperty("finalBlows", NullValueHandling = NullValueHandling.Ignore)]
        public long? FinalBlows { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("objectiveKills")] public long ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public string ObjectiveTime { get; set; }

        [JsonProperty("soloKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? SoloKills { get; set; }

        [JsonProperty("timeSpentOnFire", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeSpentOnFire { get; set; }

        [JsonProperty("criticalHits", NullValueHandling = NullValueHandling.Ignore)]
        public long? CriticalHits { get; set; }

        [JsonProperty("criticalHitsAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public string CriticalHitsAccuracy { get; set; }

        [JsonProperty("meleeFinalBlows", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeleeFinalBlows { get; set; }

        [JsonProperty("multikills", NullValueHandling = NullValueHandling.Ignore)]
        public long? Multikills { get; set; }

        [JsonProperty("quickMeleeAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public long? QuickMeleeAccuracy { get; set; }

        [JsonProperty("weaponAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public string WeaponAccuracy { get; set; }
    }

    public class Deaths
    {
        [JsonProperty("deaths")] public long DeathsDeaths { get; set; }
    }

    public class PurpleGame
    {
        [JsonProperty("gamesLost")] public long GamesLost { get; set; }

        [JsonProperty("gamesPlayed")] public long GamesPlayed { get; set; }

        [JsonProperty("gamesWon", NullValueHandling = NullValueHandling.Ignore)]
        public long? GamesWon { get; set; }

        [JsonProperty("timePlayed")] public string TimePlayed { get; set; }

        [JsonProperty("winPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public string WinPercentage { get; set; }
    }

    public class HeroSpecific
    {
    }

    public class PurpleMiscellaneous
    {
        [JsonProperty("damageDone")] public long DamageDone { get; set; }

        [JsonProperty("turretsDestroyed")] public long TurretsDestroyed { get; set; }
    }

    public class PurpleAna
    {
        [JsonProperty("assists")] public AnaAssists Assists { get; set; }

        [JsonProperty("average")] public AnaAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public AnaCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public AnaHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class AnaAssists
    {
        [JsonProperty("defensiveAssists")] public long DefensiveAssists { get; set; }

        [JsonProperty("defensiveAssistsMostInGame")]
        public long DefensiveAssistsMostInGame { get; set; }

        [JsonProperty("healingDone")] public long HealingDone { get; set; }

        [JsonProperty("healingDoneMostInGame")]
        public long HealingDoneMostInGame { get; set; }

        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }

        [JsonProperty("offensiveAssistsMostInGame")]
        public long OffensiveAssistsMostInGame { get; set; }

        [JsonProperty("turretsDestroyed", NullValueHandling = NullValueHandling.Ignore)]
        public long? TurretsDestroyed { get; set; }

        [JsonProperty("teleporterPadsDestroyed", NullValueHandling = NullValueHandling.Ignore)]
        public long? TeleporterPadsDestroyed { get; set; }
    }

    public class AnaAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("defensiveAssists")] public long DefensiveAssists { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("eliminationsPerLife")] public double EliminationsPerLife { get; set; }

        [JsonProperty("enemiesSlept", NullValueHandling = NullValueHandling.Ignore)]
        public long? EnemiesSlept { get; set; }

        [JsonProperty("finalBlows")] public long FinalBlows { get; set; }

        [JsonProperty("healingDone")] public long HealingDone { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("nanoBoostAssists", NullValueHandling = NullValueHandling.Ignore)]
        public long? NanoBoostAssists { get; set; }

        [JsonProperty("nanoBoostsApplied", NullValueHandling = NullValueHandling.Ignore)]
        public long? NanoBoostsApplied { get; set; }

        [JsonProperty("objectiveKills")] public long ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }

        [JsonProperty("scopedAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public string ScopedAccuracy { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("unscopedAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public long? UnscopedAccuracy { get; set; }

        [JsonProperty("meleeFinalBlows", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeleeFinalBlows { get; set; }

        [JsonProperty("soloKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? SoloKills { get; set; }

        [JsonProperty("timeSpentOnFire", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimeSpentOnFire { get; set; }

        [JsonProperty("blasterKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? BlasterKills { get; set; }

        [JsonProperty("criticalHits", NullValueHandling = NullValueHandling.Ignore)]
        public long? CriticalHits { get; set; }

        [JsonProperty("damageAmplified", NullValueHandling = NullValueHandling.Ignore)]
        public long? DamageAmplified { get; set; }

        [JsonProperty("playersResurrected", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayersResurrected { get; set; }
    }

    public class PurpleBest
    {
        [JsonProperty("allDamageDoneMostInGame")]
        public long AllDamageDoneMostInGame { get; set; }

        [JsonProperty("allDamageDoneMostInLife")]
        public long AllDamageDoneMostInLife { get; set; }

        [JsonProperty("barrierDamageDoneMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? BarrierDamageDoneMostInGame { get; set; }

        [JsonProperty("eliminationsMostInGame")]
        public long EliminationsMostInGame { get; set; }

        [JsonProperty("eliminationsMostInLife")]
        public long EliminationsMostInLife { get; set; }

        [JsonProperty("finalBlowsMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? FinalBlowsMostInGame { get; set; }

        [JsonProperty("heroDamageDoneMostInGame")]
        public long HeroDamageDoneMostInGame { get; set; }

        [JsonProperty("heroDamageDoneMostInLife")]
        public long HeroDamageDoneMostInLife { get; set; }

        [JsonProperty("killsStreakBest")] public long KillsStreakBest { get; set; }

        [JsonProperty("objectiveKillsMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? ObjectiveKillsMostInGame { get; set; }

        [JsonProperty("objectiveTimeMostInGame")]
        public string ObjectiveTimeMostInGame { get; set; }

        [JsonProperty("soloKillsMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? SoloKillsMostInGame { get; set; }

        [JsonProperty("timeSpentOnFireMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimeSpentOnFireMostInGame { get; set; }

        [JsonProperty("meleeFinalBlowsMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeleeFinalBlowsMostInGame { get; set; }

        [JsonProperty("multikillsBest", NullValueHandling = NullValueHandling.Ignore)]
        public long? MultikillsBest { get; set; }

        [JsonProperty("weaponAccuracyBestInGame", NullValueHandling = NullValueHandling.Ignore)]
        public string WeaponAccuracyBestInGame { get; set; }

        [JsonProperty("criticalHitsMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? CriticalHitsMostInGame { get; set; }

        [JsonProperty("criticalHitsMostInLife", NullValueHandling = NullValueHandling.Ignore)]
        public long? CriticalHitsMostInLife { get; set; }
    }

    public class AnaCombat
    {
        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("damageDone")] public long DamageDone { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("finalBlows")] public long FinalBlows { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("objectiveKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public string ObjectiveTime { get; set; }

        [JsonProperty("quickMeleeAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public long? QuickMeleeAccuracy { get; set; }

        [JsonProperty("weaponAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public string WeaponAccuracy { get; set; }
    }

    public class AnaHeroSpecific
    {
        [JsonProperty("bioticGrenadeKills")] public long BioticGrenadeKills { get; set; }

        [JsonProperty("enemiesSlept")] public long EnemiesSlept { get; set; }

        [JsonProperty("enemiesSleptMostInGame")]
        public long EnemiesSleptMostInGame { get; set; }

        [JsonProperty("nanoBoostAssists")] public long NanoBoostAssists { get; set; }

        [JsonProperty("nanoBoostAssistsMostInGame")]
        public long NanoBoostAssistsMostInGame { get; set; }

        [JsonProperty("nanoBoostsApplied")] public long NanoBoostsApplied { get; set; }

        [JsonProperty("nanoBoostsAppliedMostInGame")]
        public long NanoBoostsAppliedMostInGame { get; set; }

        [JsonProperty("scopedAccuracyBestInGame")]
        public string ScopedAccuracyBestInGame { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }

        [JsonProperty("unscopedAccuracyBestInGame")]
        public long UnscopedAccuracyBestInGame { get; set; }
    }

    public class PurpleBastion
    {
        [JsonProperty("assists")] public HeroSpecific Assists { get; set; }

        [JsonProperty("average")] public BastionAverage Average { get; set; }

        [JsonProperty("best")] public BastionBest Best { get; set; }

        [JsonProperty("combat")] public BastionCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public PurpleHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public BastionMatchAwards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class BastionAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }
    }

    public class BastionBest
    {
        [JsonProperty("allDamageDoneMostInGame")]
        public long AllDamageDoneMostInGame { get; set; }

        [JsonProperty("allDamageDoneMostInLife")]
        public long AllDamageDoneMostInLife { get; set; }

        [JsonProperty("barrierDamageDoneMostInGame")]
        public long BarrierDamageDoneMostInGame { get; set; }

        [JsonProperty("heroDamageDoneMostInGame")]
        public long HeroDamageDoneMostInGame { get; set; }

        [JsonProperty("heroDamageDoneMostInLife")]
        public long HeroDamageDoneMostInLife { get; set; }

        [JsonProperty("objectiveTimeMostInGame")]
        public string ObjectiveTimeMostInGame { get; set; }

        [JsonProperty("weaponAccuracyBestInGame", NullValueHandling = NullValueHandling.Ignore)]
        public string WeaponAccuracyBestInGame { get; set; }
    }

    public class BastionCombat
    {
        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("damageDone")] public long DamageDone { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("objectiveTime")] public string ObjectiveTime { get; set; }

        [JsonProperty("weaponAccuracy")] public string WeaponAccuracy { get; set; }
    }

    public class PurpleHeroSpecific
    {
        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }
    }

    public class BastionMatchAwards
    {
        [JsonProperty("medals")] public long Medals { get; set; }

        [JsonProperty("medalsSilver")] public long MedalsSilver { get; set; }
    }

    public class PurpleBrigitte
    {
        [JsonProperty("assists")] public BrigitteAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public BrigitteHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public BrigitteMiscellaneous Miscellaneous { get; set; }
    }

    public class PurpleAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("barrierDamageDone", NullValueHandling = NullValueHandling.Ignore)]
        public long? BarrierDamageDone { get; set; }

        [JsonProperty("damageBlocked", NullValueHandling = NullValueHandling.Ignore)]
        public long? DamageBlocked { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("eliminationsPerLife")] public double EliminationsPerLife { get; set; }

        [JsonProperty("finalBlows")] public long FinalBlows { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("jumpPackKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? JumpPackKills { get; set; }

        [JsonProperty("meleeFinalBlows", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeleeFinalBlows { get; set; }

        [JsonProperty("meleeKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeleeKills { get; set; }

        [JsonProperty("objectiveKills")] public long ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("playersKnockedBack", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayersKnockedBack { get; set; }

        [JsonProperty("primalRageKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? PrimalRageKills { get; set; }

        [JsonProperty("soloKills")] public long SoloKills { get; set; }

        [JsonProperty("timeSpentOnFire", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimeSpentOnFire { get; set; }

        [JsonProperty("criticalHits", NullValueHandling = NullValueHandling.Ignore)]
        public long? CriticalHits { get; set; }

        [JsonProperty("deadeyeKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeadeyeKills { get; set; }

        [JsonProperty("fanTheHammerKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? FanTheHammerKills { get; set; }

        [JsonProperty("chargeKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? ChargeKills { get; set; }

        [JsonProperty("earthshatterKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? EarthshatterKills { get; set; }

        [JsonProperty("fireStrikeKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? FireStrikeKills { get; set; }

        [JsonProperty("offensiveAssists", NullValueHandling = NullValueHandling.Ignore)]
        public long? OffensiveAssists { get; set; }

        [JsonProperty("armorProvided", NullValueHandling = NullValueHandling.Ignore)]
        public long? ArmorProvided { get; set; }

        [JsonProperty("defensiveAssists", NullValueHandling = NullValueHandling.Ignore)]
        public long? DefensiveAssists { get; set; }

        [JsonProperty("healingDone", NullValueHandling = NullValueHandling.Ignore)]
        public long? HealingDone { get; set; }

        [JsonProperty("selfHealing", NullValueHandling = NullValueHandling.Ignore)]
        public long? SelfHealing { get; set; }

        [JsonProperty("mechsCalled", NullValueHandling = NullValueHandling.Ignore)]
        public long? MechsCalled { get; set; }

        [JsonProperty("selfDestructKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? SelfDestructKills { get; set; }

        [JsonProperty("blizzardKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? BlizzardKills { get; set; }

        [JsonProperty("enemiesFrozen", NullValueHandling = NullValueHandling.Ignore)]
        public long? EnemiesFrozen { get; set; }

        [JsonProperty("abilityDamageDone", NullValueHandling = NullValueHandling.Ignore)]
        public long? AbilityDamageDone { get; set; }

        [JsonProperty("meteorStrikeKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeteorStrikeKills { get; set; }

        [JsonProperty("shieldsCreated", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShieldsCreated { get; set; }

        [JsonProperty("damageReflected", NullValueHandling = NullValueHandling.Ignore)]
        public long? DamageReflected { get; set; }

        [JsonProperty("dragonbladesKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? DragonbladesKills { get; set; }

        [JsonProperty("helixRocketsKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? HelixRocketsKills { get; set; }

        [JsonProperty("tacticalVisorKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? TacticalVisorKills { get; set; }

        [JsonProperty("coalescenceHealing", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoalescenceHealing { get; set; }

        [JsonProperty("coalescenceKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? CoalescenceKills { get; set; }

        [JsonProperty("playersTeleported", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayersTeleported { get; set; }

        [JsonProperty("sentryTurretsKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? SentryTurretsKills { get; set; }

        [JsonProperty("teleporterUptimeAverage", NullValueHandling = NullValueHandling.Ignore)]
        public double? TeleporterUptimeAverage { get; set; }

        [JsonProperty("dragonstrikeKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? DragonstrikeKills { get; set; }

        [JsonProperty("reconAssists", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReconAssists { get; set; }

        [JsonProperty("scatterArrowKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? ScatterArrowKills { get; set; }

        [JsonProperty("stormArrowKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? StormArrowKills { get; set; }

        [JsonProperty("damageAmplified", NullValueHandling = NullValueHandling.Ignore)]
        public long? DamageAmplified { get; set; }

        [JsonProperty("superchargerAssists", NullValueHandling = NullValueHandling.Ignore)]
        public long? SuperchargerAssists { get; set; }

        [JsonProperty("concussionMineKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? ConcussionMineKills { get; set; }

        [JsonProperty("enemiesTrapped", NullValueHandling = NullValueHandling.Ignore)]
        public long? EnemiesTrapped { get; set; }

        [JsonProperty("ripTireKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? RipTireKills { get; set; }

        [JsonProperty("blasterKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? BlasterKills { get; set; }

        [JsonProperty("playersResurrected", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayersResurrected { get; set; }

        [JsonProperty("reconKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReconKills { get; set; }

        [JsonProperty("sentryKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? SentryKills { get; set; }

        [JsonProperty("tankKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? TankKills { get; set; }

        [JsonProperty("soundBarriersProvided", NullValueHandling = NullValueHandling.Ignore)]
        public long? SoundBarriersProvided { get; set; }
    }

    public class BrigitteHeroSpecific
    {
        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }
    }

    public class BrigitteMiscellaneous
    {
        [JsonProperty("armorProvided")] public long ArmorProvided { get; set; }

        [JsonProperty("armorProvidedMostInGame")]
        public long ArmorProvidedMostInGame { get; set; }

        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("damageBlockedMostInGame")]
        public long DamageBlockedMostInGame { get; set; }
    }

    public class PurpleJunkrat
    {
        [JsonProperty("assists")] public PurpleAssists Assists { get; set; }

        [JsonProperty("average")] public JunkratAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public JunkratHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class PurpleAssists
    {
        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }

        [JsonProperty("offensiveAssistsMostInGame")]
        public long OffensiveAssistsMostInGame { get; set; }
    }

    public class JunkratAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("concussionMineKills")] public long ConcussionMineKills { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("eliminationsPerLife")] public double EliminationsPerLife { get; set; }

        [JsonProperty("enemiesTrapped")] public long EnemiesTrapped { get; set; }

        [JsonProperty("finalBlows")] public long FinalBlows { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("objectiveKills")] public long ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }

        [JsonProperty("ripTireKills")] public long RipTireKills { get; set; }

        [JsonProperty("soloKills")] public long SoloKills { get; set; }

        [JsonProperty("timeSpentOnFire")] public long TimeSpentOnFire { get; set; }
    }

    public class JunkratHeroSpecific
    {
        [JsonProperty("concussionMineKills")] public long ConcussionMineKills { get; set; }

        [JsonProperty("concussionMineKillsMostInGame")]
        public long ConcussionMineKillsMostInGame { get; set; }

        [JsonProperty("enemiesTrapped")] public long EnemiesTrapped { get; set; }

        [JsonProperty("enemiesTrappedMostInGame")]
        public long EnemiesTrappedMostInGame { get; set; }

        [JsonProperty("ripTireKills")] public long RipTireKills { get; set; }

        [JsonProperty("ripTireKillsMostInGame")]
        public long RipTireKillsMostInGame { get; set; }
    }

    public class PurpleLucio
    {
        [JsonProperty("assists")] public AnaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public LucioHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class LucioHeroSpecific
    {
        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }

        [JsonProperty("soundBarriersProvided")]
        public long SoundBarriersProvided { get; set; }

        [JsonProperty("soundBarriersProvidedMostInGame")]
        public long SoundBarriersProvidedMostInGame { get; set; }
    }

    public class PurpleMccree
    {
        [JsonProperty("assists")] public HeroSpecific Assists { get; set; }

        [JsonProperty("average")] public MccreeAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public MccreeHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class MccreeAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("criticalHits")] public long CriticalHits { get; set; }

        [JsonProperty("deadeyeKills")] public long DeadeyeKills { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("eliminationsPerLife")] public double EliminationsPerLife { get; set; }

        [JsonProperty("fanTheHammerKills")] public long FanTheHammerKills { get; set; }

        [JsonProperty("finalBlows")] public long FinalBlows { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("objectiveKills")] public long ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("soloKills")] public long SoloKills { get; set; }
    }

    public class MccreeHeroSpecific
    {
        [JsonProperty("deadeyeKills")] public long DeadeyeKills { get; set; }

        [JsonProperty("deadeyeKillsMostInGame")]
        public long DeadeyeKillsMostInGame { get; set; }

        [JsonProperty("fanTheHammerKills")] public long FanTheHammerKills { get; set; }

        [JsonProperty("fanTheHammerKillsMostInGame")]
        public long FanTheHammerKillsMostInGame { get; set; }
    }

    public class PurpleMei
    {
        [JsonProperty("assists")] public PurpleAssists Assists { get; set; }

        [JsonProperty("average")] public MeiAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public MeiHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class MeiAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("blizzardKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? BlizzardKills { get; set; }

        [JsonProperty("criticalHits")] public long CriticalHits { get; set; }

        [JsonProperty("damageBlocked", NullValueHandling = NullValueHandling.Ignore)]
        public long? DamageBlocked { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("eliminationsPerLife")] public double EliminationsPerLife { get; set; }

        [JsonProperty("enemiesFrozen", NullValueHandling = NullValueHandling.Ignore)]
        public long? EnemiesFrozen { get; set; }

        [JsonProperty("finalBlows")] public long FinalBlows { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("objectiveKills")] public long ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("enemiesHooked", NullValueHandling = NullValueHandling.Ignore)]
        public long? EnemiesHooked { get; set; }

        [JsonProperty("hookAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public string HookAccuracy { get; set; }
    }

    public class MeiHeroSpecific
    {
        [JsonProperty("blizzardKills")] public long BlizzardKills { get; set; }

        [JsonProperty("blizzardKillsMostInGame")]
        public long BlizzardKillsMostInGame { get; set; }

        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("damageBlockedMostInGame")]
        public long DamageBlockedMostInGame { get; set; }

        [JsonProperty("enemiesFrozen")] public long EnemiesFrozen { get; set; }

        [JsonProperty("enemiesFrozenMostInGame")]
        public long EnemiesFrozenMostInGame { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }
    }

    public class PurpleMercy
    {
        [JsonProperty("assists")] public AnaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public MercyHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class MercyHeroSpecific
    {
        [JsonProperty("blasterKills")] public long BlasterKills { get; set; }

        [JsonProperty("blasterKillsMostInGame")]
        public long BlasterKillsMostInGame { get; set; }

        [JsonProperty("damageAmplified")] public long DamageAmplified { get; set; }

        [JsonProperty("damageAmplifiedMostInGame")]
        public long DamageAmplifiedMostInGame { get; set; }

        [JsonProperty("playersResurrected")] public long PlayersResurrected { get; set; }

        [JsonProperty("playersResurrectedMostInGame")]
        public long PlayersResurrectedMostInGame { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }
    }

    public class PurpleMoira
    {
        [JsonProperty("assists")] public FluffyAssists Assists { get; set; }

        [JsonProperty("average")] public MoiraAverage Average { get; set; }

        [JsonProperty("best")] public BastionBest Best { get; set; }

        [JsonProperty("combat")] public MoiraCombat Combat { get; set; }

        [JsonProperty("deaths")] public HeroSpecific Deaths { get; set; }

        [JsonProperty("heroSpecific")] public FluffyHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public MoiraMatchAwards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class FluffyAssists
    {
        [JsonProperty("healingDone")] public long HealingDone { get; set; }

        [JsonProperty("healingDoneMostInGame")]
        public long HealingDoneMostInGame { get; set; }
    }

    public class MoiraAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("coalescenceHealing")] public long CoalescenceHealing { get; set; }

        [JsonProperty("healingDone")] public long HealingDone { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }
    }

    public class MoiraCombat
    {
        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("damageDone")] public long DamageDone { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("objectiveTime")] public string ObjectiveTime { get; set; }
    }

    public class FluffyHeroSpecific
    {
        [JsonProperty("coalescenceHealing")] public long CoalescenceHealing { get; set; }

        [JsonProperty("coalescenceHealingMostInGame")]
        public long CoalescenceHealingMostInGame { get; set; }

        [JsonProperty("secondaryFireAccuracy")]
        public long SecondaryFireAccuracy { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }
    }

    public class MoiraMatchAwards
    {
        [JsonProperty("medals")] public long Medals { get; set; }

        [JsonProperty("medalsGold")] public long MedalsGold { get; set; }
    }

    public class PurplePharah
    {
        [JsonProperty("assists")] public HeroSpecific Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public PharahHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class PharahHeroSpecific
    {
        [JsonProperty("barrageKills")] public long BarrageKills { get; set; }

        [JsonProperty("barrageKillsMostInGame")]
        public long BarrageKillsMostInGame { get; set; }

        [JsonProperty("rocketDirectHits")] public long RocketDirectHits { get; set; }

        [JsonProperty("rocketDirectHitsMostInGame")]
        public long RocketDirectHitsMostInGame { get; set; }
    }

    public class PurpleReaper
    {
        [JsonProperty("assists")] public HeroSpecific Assists { get; set; }

        [JsonProperty("average")] public HeroSpecific Average { get; set; }

        [JsonProperty("best")] public HeroSpecific Best { get; set; }

        [JsonProperty("combat")] public HeroSpecific Combat { get; set; }

        [JsonProperty("deaths")] public HeroSpecific Deaths { get; set; }

        [JsonProperty("heroSpecific")] public HeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class PurpleReinhardt
    {
        [JsonProperty("assists")] public PurpleAssists Assists { get; set; }

        [JsonProperty("average")] public ReinhardtAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public AnaCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public ReinhardtHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class ReinhardtAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("chargeKills")] public long ChargeKills { get; set; }

        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("earthshatterKills")] public long EarthshatterKills { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("eliminationsPerLife")] public long EliminationsPerLife { get; set; }

        [JsonProperty("finalBlows")] public long FinalBlows { get; set; }

        [JsonProperty("fireStrikeKills")] public long FireStrikeKills { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("objectiveKills")] public long ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }
    }

    public class ReinhardtHeroSpecific
    {
        [JsonProperty("chargeKills")] public long ChargeKills { get; set; }

        [JsonProperty("chargeKillsMostInGame")]
        public long ChargeKillsMostInGame { get; set; }

        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("damageBlockedMostInGame")]
        public long DamageBlockedMostInGame { get; set; }

        [JsonProperty("earthshatterKills")] public long EarthshatterKills { get; set; }

        [JsonProperty("earthshatterKillsMostInGame")]
        public long EarthshatterKillsMostInGame { get; set; }

        [JsonProperty("fireStrikeKills")] public long FireStrikeKills { get; set; }

        [JsonProperty("fireStrikeKillsMostInGame")]
        public long FireStrikeKillsMostInGame { get; set; }

        [JsonProperty("rocketHammerMeleeAccuracy")]
        public long RocketHammerMeleeAccuracy { get; set; }
    }

    public class PurpleRoadhog
    {
        [JsonProperty("assists")] public PurpleAssists Assists { get; set; }

        [JsonProperty("average")] public MeiAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public RoadhogHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class RoadhogHeroSpecific
    {
        [JsonProperty("enemiesHooked")] public long EnemiesHooked { get; set; }

        [JsonProperty("enemiesHookedMostInGame")]
        public long EnemiesHookedMostInGame { get; set; }

        [JsonProperty("hookAccuracyBestInGame")]
        public string HookAccuracyBestInGame { get; set; }

        [JsonProperty("hooksAttempted")] public long HooksAttempted { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }

        [JsonProperty("wholeHogKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? WholeHogKills { get; set; }

        [JsonProperty("wholeHogKillsMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? WholeHogKillsMostInGame { get; set; }
    }

    public class PurpleSoldier76
    {
        [JsonProperty("assists")] public Soldier76Assists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public Soldier76HeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class Soldier76Assists
    {
        [JsonProperty("defensiveAssists")] public long DefensiveAssists { get; set; }

        [JsonProperty("defensiveAssistsMostInGame")]
        public long DefensiveAssistsMostInGame { get; set; }

        [JsonProperty("healingDone")] public long HealingDone { get; set; }

        [JsonProperty("healingDoneMostInGame")]
        public long HealingDoneMostInGame { get; set; }

        [JsonProperty("turretsDestroyed", NullValueHandling = NullValueHandling.Ignore)]
        public long? TurretsDestroyed { get; set; }
    }

    public class Soldier76HeroSpecific
    {
        [JsonProperty("bioticFieldHealingDone")]
        public long BioticFieldHealingDone { get; set; }

        [JsonProperty("bioticFieldsDeployed")] public long BioticFieldsDeployed { get; set; }

        [JsonProperty("helixRocketsKills")] public long HelixRocketsKills { get; set; }

        [JsonProperty("helixRocketsKillsMostInGame")]
        public long HelixRocketsKillsMostInGame { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }

        [JsonProperty("tacticalVisorKills")] public long TacticalVisorKills { get; set; }

        [JsonProperty("tacticalVisorKillsMostInGame")]
        public long TacticalVisorKillsMostInGame { get; set; }
    }

    public class PurpleWinston
    {
        [JsonProperty("assists")] public HeroSpecific Assists { get; set; }

        [JsonProperty("average")] public WinstonAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public AnaCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public WinstonHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public BastionMatchAwards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public FluffyMiscellaneous Miscellaneous { get; set; }
    }

    public class WinstonAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("eliminationsPerLife")] public double EliminationsPerLife { get; set; }

        [JsonProperty("finalBlows")] public long FinalBlows { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("jumpPackKills")] public long JumpPackKills { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("playersKnockedBack")] public long PlayersKnockedBack { get; set; }

        [JsonProperty("primalRageKills")] public long PrimalRageKills { get; set; }
    }

    public class WinstonHeroSpecific
    {
        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("damageBlockedMostInGame")]
        public long DamageBlockedMostInGame { get; set; }

        [JsonProperty("jumpPackKills")] public long JumpPackKills { get; set; }

        [JsonProperty("jumpPackKillsMostInGame")]
        public long JumpPackKillsMostInGame { get; set; }

        [JsonProperty("playersKnockedBack")] public long PlayersKnockedBack { get; set; }

        [JsonProperty("playersKnockedBackMostInGame")]
        public long PlayersKnockedBackMostInGame { get; set; }

        [JsonProperty("primalRageKills")] public long PrimalRageKills { get; set; }

        [JsonProperty("primalRageKillsMostInGame")]
        public long PrimalRageKillsMostInGame { get; set; }

        [JsonProperty("primalRageMeleeAccuracy")]
        public long PrimalRageMeleeAccuracy { get; set; }

        [JsonProperty("teslaCannonAccuracy")] public long TeslaCannonAccuracy { get; set; }

        [JsonProperty("meleeKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeleeKills { get; set; }

        [JsonProperty("meleeKillsMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? MeleeKillsMostInGame { get; set; }
    }

    public class FluffyMiscellaneous
    {
        [JsonProperty("jumpKills")] public long JumpKills { get; set; }

        [JsonProperty("weaponKills")] public long WeaponKills { get; set; }
    }

    public class PurpleZarya
    {
        [JsonProperty("assists")] public TentacledAssists Assists { get; set; }

        [JsonProperty("average")] public FluffyAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public ZaryaHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class TentacledAssists
    {
        [JsonProperty("defensiveAssists")] public long DefensiveAssists { get; set; }

        [JsonProperty("defensiveAssistsMostInGame")]
        public long DefensiveAssistsMostInGame { get; set; }
    }

    public class FluffyAverage
    {
        [JsonProperty("allDamageDone")] public double AllDamageDone { get; set; }

        [JsonProperty("averageEnergy")] public double AverageEnergy { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("defensiveAssists")] public long DefensiveAssists { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("eliminationsPerLife")] public long EliminationsPerLife { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("highEnergyKills")] public long HighEnergyKills { get; set; }

        [JsonProperty("objectiveKills")] public long ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("projectedBarriersApplied")]
        public long ProjectedBarriersApplied { get; set; }

        [JsonProperty("timeSpentOnFire")] public long TimeSpentOnFire { get; set; }
    }

    public class ZaryaHeroSpecific
    {
        [JsonProperty("averageEnergyBestInGame")]
        public long AverageEnergyBestInGame { get; set; }

        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("damageBlockedMostInGame")]
        public long DamageBlockedMostInGame { get; set; }

        [JsonProperty("highEnergyKills")] public long HighEnergyKills { get; set; }

        [JsonProperty("highEnergyKillsMostInGame")]
        public long HighEnergyKillsMostInGame { get; set; }

        [JsonProperty("primaryFireAccuracy")] public long PrimaryFireAccuracy { get; set; }

        [JsonProperty("projectedBarriersApplied")]
        public long ProjectedBarriersApplied { get; set; }

        [JsonProperty("projectedBarriersAppliedMostInGame")]
        public long ProjectedBarriersAppliedMostInGame { get; set; }

        [JsonProperty("gravitonSurgeKills", NullValueHandling = NullValueHandling.Ignore)]
        public long? GravitonSurgeKills { get; set; }

        [JsonProperty("gravitonSurgeKillsMostInGame", NullValueHandling = NullValueHandling.Ignore)]
        public long? GravitonSurgeKillsMostInGame { get; set; }
    }

    public class PurpleZenyatta
    {
        [JsonProperty("assists")] public AnaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public ZenyattaHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public PurpleGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class ZenyattaHeroSpecific
    {
        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }

        [JsonProperty("transcendenceHealing")] public long TranscendenceHealing { get; set; }

        [JsonProperty("transcendenceHealingBest")]
        public long TranscendenceHealingBest { get; set; }
    }

    public class Games
    {
        [JsonProperty("played")] public long Played { get; set; }

        [JsonProperty("won")] public long Won { get; set; }
    }

    public class TopHeroes
    {
        [JsonProperty("ana")] public BimtehkaYellowjacket Ana { get; set; }

        [JsonProperty("bastion")] public BimtehkaYellowjacket Bastion { get; set; }

        [JsonProperty("brigitte")] public BimtehkaYellowjacket Brigitte { get; set; }

        [JsonProperty("dVa")] public BimtehkaYellowjacket DVa { get; set; }

        [JsonProperty("doomfist")] public BimtehkaYellowjacket Doomfist { get; set; }

        [JsonProperty("genji")] public BimtehkaYellowjacket Genji { get; set; }

        [JsonProperty("hanzo")] public BimtehkaYellowjacket Hanzo { get; set; }

        [JsonProperty("junkrat")] public BimtehkaYellowjacket Junkrat { get; set; }

        [JsonProperty("lucio")] public BimtehkaYellowjacket Lucio { get; set; }

        [JsonProperty("mccree")] public BimtehkaYellowjacket Mccree { get; set; }

        [JsonProperty("mei")] public BimtehkaYellowjacket Mei { get; set; }

        [JsonProperty("mercy")] public BimtehkaYellowjacket Mercy { get; set; }

        [JsonProperty("moira")] public BimtehkaYellowjacket Moira { get; set; }

        [JsonProperty("orisa")] public BimtehkaYellowjacket Orisa { get; set; }

        [JsonProperty("pharah")] public BimtehkaYellowjacket Pharah { get; set; }

        [JsonProperty("reaper")] public BimtehkaYellowjacket Reaper { get; set; }

        [JsonProperty("reinhardt")] public BimtehkaYellowjacket Reinhardt { get; set; }

        [JsonProperty("roadhog")] public BimtehkaYellowjacket Roadhog { get; set; }

        [JsonProperty("soldier76")] public BimtehkaYellowjacket Soldier76 { get; set; }

        [JsonProperty("sombra")] public BimtehkaYellowjacket Sombra { get; set; }

        [JsonProperty("symmetra")] public BimtehkaYellowjacket Symmetra { get; set; }

        [JsonProperty("torbjorn")] public BimtehkaYellowjacket Torbjorn { get; set; }

        [JsonProperty("tracer")] public BimtehkaYellowjacket Tracer { get; set; }

        [JsonProperty("widowmaker")] public BimtehkaYellowjacket Widowmaker { get; set; }

        [JsonProperty("winston")] public BimtehkaYellowjacket Winston { get; set; }

        [JsonProperty("zarya")] public BimtehkaYellowjacket Zarya { get; set; }

        [JsonProperty("zenyatta")] public BimtehkaYellowjacket Zenyatta { get; set; }
    }

    public class BimtehkaYellowjacket
    {
        [JsonProperty("timePlayed")] public string TimePlayed { get; set; }

        [JsonProperty("gamesWon")] public long GamesWon { get; set; }

        [JsonProperty("winPercentage")] public long WinPercentage { get; set; }

        [JsonProperty("weaponAccuracy")] public long WeaponAccuracy { get; set; }

        [JsonProperty("eliminationsPerLife")] public double EliminationsPerLife { get; set; }

        [JsonProperty("multiKillBest")] public long MultiKillBest { get; set; }

        [JsonProperty("objectiveKillsAvg")] public long ObjectiveKillsAvg { get; set; }
    }

    public class QuickPlayStats
    {
        [JsonProperty("eliminationsAvg")] public long EliminationsAvg { get; set; }

        [JsonProperty("damageDoneAvg")] public long DamageDoneAvg { get; set; }

        [JsonProperty("deathsAvg")] public long DeathsAvg { get; set; }

        [JsonProperty("finalBlowsAvg")] public long FinalBlowsAvg { get; set; }

        [JsonProperty("healingDoneAvg")] public long HealingDoneAvg { get; set; }

        [JsonProperty("objectiveKillsAvg")] public long ObjectiveKillsAvg { get; set; }

        [JsonProperty("objectiveTimeAvg")] public string ObjectiveTimeAvg { get; set; }

        [JsonProperty("soloKillsAvg")] public long SoloKillsAvg { get; set; }

        [JsonProperty("games")] public Games Games { get; set; }

        [JsonProperty("awards")] public Awards Awards { get; set; }

        [JsonProperty("topHeroes")] public TopHeroes TopHeroes { get; set; }

        [JsonProperty("careerStats")] public QuickPlayStatsCareerStats CareerStats { get; set; }
    }

    public class QuickPlayStatsCareerStats
    {
        [JsonProperty("allHeroes")] public FluffyAllHeroes AllHeroes { get; set; }

        [JsonProperty("ana")] public FluffyAna Ana { get; set; }

        [JsonProperty("bastion")] public FluffyBastion Bastion { get; set; }

        [JsonProperty("brigitte")] public FluffyBrigitte Brigitte { get; set; }

        [JsonProperty("dVa")] public DVa DVa { get; set; }

        [JsonProperty("doomfist")] public Doomfist Doomfist { get; set; }

        [JsonProperty("genji")] public Genji Genji { get; set; }

        [JsonProperty("hanzo")] public Hanzo Hanzo { get; set; }

        [JsonProperty("junkrat")] public FluffyJunkrat Junkrat { get; set; }

        [JsonProperty("lucio")] public FluffyLucio Lucio { get; set; }

        [JsonProperty("mccree")] public FluffyMccree Mccree { get; set; }

        [JsonProperty("mei")] public FluffyMei Mei { get; set; }

        [JsonProperty("mercy")] public FluffyMercy Mercy { get; set; }

        [JsonProperty("moira")] public FluffyMoira Moira { get; set; }

        [JsonProperty("orisa")] public Orisa Orisa { get; set; }

        [JsonProperty("pharah")] public FluffyPharah Pharah { get; set; }

        [JsonProperty("reaper")] public FluffyReaper Reaper { get; set; }

        [JsonProperty("reinhardt")] public FluffyReinhardt Reinhardt { get; set; }

        [JsonProperty("roadhog")] public FluffyRoadhog Roadhog { get; set; }

        [JsonProperty("soldier76")] public FluffySoldier76 Soldier76 { get; set; }

        [JsonProperty("sombra")] public Sombra Sombra { get; set; }

        [JsonProperty("symmetra")] public Symmetra Symmetra { get; set; }

        [JsonProperty("torbjorn")] public Torbjorn Torbjorn { get; set; }

        [JsonProperty("tracer")] public Tracer Tracer { get; set; }

        [JsonProperty("widowmaker")] public Widowmaker Widowmaker { get; set; }

        [JsonProperty("winston")] public FluffyWinston Winston { get; set; }

        [JsonProperty("zarya")] public FluffyZarya Zarya { get; set; }

        [JsonProperty("zenyatta")] public FluffyZenyatta Zenyatta { get; set; }
    }

    public class FluffyAllHeroes
    {
        [JsonProperty("assists")] public StickyAssists Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public AllHeroesBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public HeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public TentacledMiscellaneous Miscellaneous { get; set; }
    }

    public class StickyAssists
    {
        [JsonProperty("defensiveAssists")] public long DefensiveAssists { get; set; }

        [JsonProperty("healingDone")] public long HealingDone { get; set; }

        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }

        [JsonProperty("reconAssists")] public long ReconAssists { get; set; }

        [JsonProperty("teleporterPadsDestroyed")]
        public long TeleporterPadsDestroyed { get; set; }
    }

    public class FluffyGame
    {
        [JsonProperty("gamesWon")] public long GamesWon { get; set; }

        [JsonProperty("timePlayed")] public string TimePlayed { get; set; }
    }

    public class TentacledMiscellaneous
    {
        [JsonProperty("damageDone")] public long DamageDone { get; set; }

        [JsonProperty("shieldsGeneratorsDestroyed")]
        public long ShieldsGeneratorsDestroyed { get; set; }

        [JsonProperty("turretsDestroyed")] public long TurretsDestroyed { get; set; }
    }

    public class FluffyAna
    {
        [JsonProperty("assists")] public AnaAssists Assists { get; set; }

        [JsonProperty("average")] public AnaAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public AnaHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class FluffyBastion
    {
        [JsonProperty("assists")] public BastionAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public TentacledHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class BastionAssists
    {
        [JsonProperty("teleporterPadsDestroyed")]
        public long TeleporterPadsDestroyed { get; set; }

        [JsonProperty("turretsDestroyed")] public long TurretsDestroyed { get; set; }
    }

    public class TentacledHeroSpecific
    {
        [JsonProperty("reconKills")] public long ReconKills { get; set; }

        [JsonProperty("reconKillsMostInGame")] public long ReconKillsMostInGame { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }

        [JsonProperty("sentryKills")] public long SentryKills { get; set; }

        [JsonProperty("sentryKillsMostInGame")]
        public long SentryKillsMostInGame { get; set; }

        [JsonProperty("tankKills")] public long TankKills { get; set; }

        [JsonProperty("tankKillsMostInGame")] public long TankKillsMostInGame { get; set; }
    }

    public class FluffyBrigitte
    {
        [JsonProperty("assists")] public BrigitteAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public HeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public BrigitteMiscellaneous Miscellaneous { get; set; }
    }

    public class DVa
    {
        [JsonProperty("assists")] public DVaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public DVaHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class DVaAssists
    {
        [JsonProperty("turretsDestroyed")] public long TurretsDestroyed { get; set; }
    }

    public class DVaHeroSpecific
    {
        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("damageBlockedMostInGame")]
        public long DamageBlockedMostInGame { get; set; }

        [JsonProperty("mechDeaths")] public long MechDeaths { get; set; }

        [JsonProperty("mechsCalled")] public long MechsCalled { get; set; }

        [JsonProperty("mechsCalledMostInGame")]
        public long MechsCalledMostInGame { get; set; }

        [JsonProperty("selfDestructKills")] public long SelfDestructKills { get; set; }

        [JsonProperty("selfDestructKillsMostInGame")]
        public long SelfDestructKillsMostInGame { get; set; }
    }

    public class Doomfist
    {
        [JsonProperty("assists")] public DVaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public DoomfistHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class DoomfistHeroSpecific
    {
        [JsonProperty("abilityDamageDone")] public double AbilityDamageDone { get; set; }

        [JsonProperty("abilityDamageDoneMostInGame")]
        public double AbilityDamageDoneMostInGame { get; set; }

        [JsonProperty("meteorStrikeKills")] public long MeteorStrikeKills { get; set; }

        [JsonProperty("meteorStrikeKillsMostInGame")]
        public long MeteorStrikeKillsMostInGame { get; set; }

        [JsonProperty("shieldsCreated")] public double ShieldsCreated { get; set; }

        [JsonProperty("shieldsCreatedMostInGame")]
        public double ShieldsCreatedMostInGame { get; set; }
    }

    public class Genji
    {
        [JsonProperty("assists")] public BastionAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public GenjiHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public GenjiMiscellaneous Miscellaneous { get; set; }
    }

    public class GenjiHeroSpecific
    {
        [JsonProperty("damageReflected")] public long DamageReflected { get; set; }

        [JsonProperty("damageReflectedMostInGame")]
        public long DamageReflectedMostInGame { get; set; }

        [JsonProperty("dragonbladesKills")] public long DragonbladesKills { get; set; }

        [JsonProperty("dragonbladesKillsMostInGame")]
        public long DragonbladesKillsMostInGame { get; set; }
    }

    public class GenjiMiscellaneous
    {
        [JsonProperty("shieldGeneratorsDestroyed")]
        public long ShieldGeneratorsDestroyed { get; set; }
    }

    public class Hanzo
    {
        [JsonProperty("assists")] public HanzoAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public HanzoHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HanzoMiscellaneous Miscellaneous { get; set; }
    }

    public class HanzoAssists
    {
        [JsonProperty("reconAssists")] public long ReconAssists { get; set; }

        [JsonProperty("reconAssistsMostInGame")]
        public long ReconAssistsMostInGame { get; set; }

        [JsonProperty("turretsDestroyed")] public long TurretsDestroyed { get; set; }
    }

    public class HanzoHeroSpecific
    {
        [JsonProperty("dragonstrikeKills")] public long DragonstrikeKills { get; set; }

        [JsonProperty("dragonstrikeKillsMostInGame")]
        public long DragonstrikeKillsMostInGame { get; set; }

        [JsonProperty("scatterArrowKills")] public long ScatterArrowKills { get; set; }

        [JsonProperty("scatterArrowKillsMostInGame")]
        public long ScatterArrowKillsMostInGame { get; set; }
    }

    public class HanzoMiscellaneous
    {
        [JsonProperty("shieldGeneratorsDestroyed")]
        public long ShieldGeneratorsDestroyed { get; set; }

        [JsonProperty("stormArrowKills")] public long StormArrowKills { get; set; }

        [JsonProperty("stormArrowKillsMostInGame")]
        public long StormArrowKillsMostInGame { get; set; }
    }

    public class FluffyJunkrat
    {
        [JsonProperty("assists")] public OrisaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public JunkratHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class OrisaAssists
    {
        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }

        [JsonProperty("offensiveAssistsMostInGame")]
        public long OffensiveAssistsMostInGame { get; set; }

        [JsonProperty("teleporterPadsDestroyed", NullValueHandling = NullValueHandling.Ignore)]
        public long? TeleporterPadsDestroyed { get; set; }

        [JsonProperty("turretsDestroyed")] public long TurretsDestroyed { get; set; }
    }

    public class FluffyLucio
    {
        [JsonProperty("assists")] public AnaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public LucioHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class FluffyMccree
    {
        [JsonProperty("assists")] public MccreeAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public MccreeHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class MccreeAssists
    {
        [JsonProperty("offensiveAssistsMostInGame")]
        public long OffensiveAssistsMostInGame { get; set; }

        [JsonProperty("turretsDestroyed")] public long TurretsDestroyed { get; set; }
    }

    public class FluffyMei
    {
        [JsonProperty("assists")] public OrisaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public MeiHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class FluffyMercy
    {
        [JsonProperty("assists")] public AnaAssists Assists { get; set; }

        [JsonProperty("average")] public AnaAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public MercyHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class FluffyMoira
    {
        [JsonProperty("assists")] public Soldier76Assists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public StickyHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class StickyHeroSpecific
    {
        [JsonProperty("coalescenceHealing")] public long CoalescenceHealing { get; set; }

        [JsonProperty("coalescenceHealingMostInGame")]
        public long CoalescenceHealingMostInGame { get; set; }

        [JsonProperty("coalescenceKills")] public long CoalescenceKills { get; set; }

        [JsonProperty("coalescenceKillsMostInGame")]
        public long CoalescenceKillsMostInGame { get; set; }

        [JsonProperty("secondaryFireAccuracy")]
        public long SecondaryFireAccuracy { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }
    }

    public class Orisa
    {
        [JsonProperty("assists")] public OrisaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public OrisaHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class OrisaHeroSpecific
    {
        [JsonProperty("damageAmplified")] public long DamageAmplified { get; set; }

        [JsonProperty("damageAmplifiedMostInGame")]
        public long DamageAmplifiedMostInGame { get; set; }

        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("damageBlockedMostInGame")]
        public long DamageBlockedMostInGame { get; set; }

        [JsonProperty("superchargerAssists")] public long SuperchargerAssists { get; set; }

        [JsonProperty("superchargerAssistsMostInGame")]
        public long SuperchargerAssistsMostInGame { get; set; }
    }

    public class FluffyPharah
    {
        [JsonProperty("assists")] public BastionAssists Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public PharahHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public GenjiMiscellaneous Miscellaneous { get; set; }
    }

    public class FluffyReaper
    {
        [JsonProperty("assists")] public BastionAssists Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public ReaperHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public GenjiMiscellaneous Miscellaneous { get; set; }
    }

    public class ReaperHeroSpecific
    {
        [JsonProperty("deathsBlossomKills")] public long DeathsBlossomKills { get; set; }

        [JsonProperty("deathsBlossomKillsMostInGame")]
        public long DeathsBlossomKillsMostInGame { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }
    }

    public class FluffyReinhardt
    {
        [JsonProperty("assists")] public OrisaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public ReinhardtHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class FluffyRoadhog
    {
        [JsonProperty("assists")] public OrisaAssists Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public RoadhogHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class FluffySoldier76
    {
        [JsonProperty("assists")] public Soldier76Assists Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public Soldier76HeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class Sombra
    {
        [JsonProperty("assists")] public OrisaAssists Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public SombraHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class SombraHeroSpecific
    {
        [JsonProperty("enemiesEmpd")] public long EnemiesEmpd { get; set; }

        [JsonProperty("enemiesEmpdMostInGame")]
        public long EnemiesEmpdMostInGame { get; set; }

        [JsonProperty("enemiesHacked")] public long EnemiesHacked { get; set; }

        [JsonProperty("enemiesHackedMostInGame")]
        public long EnemiesHackedMostInGame { get; set; }
    }

    public class Symmetra
    {
        [JsonProperty("assists")] public DVaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public SymmetraHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class SymmetraHeroSpecific
    {
        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("damageBlockedMostInGame")]
        public long DamageBlockedMostInGame { get; set; }

        [JsonProperty("playersTeleported")] public long PlayersTeleported { get; set; }

        [JsonProperty("playersTeleportedMostInGame")]
        public long PlayersTeleportedMostInGame { get; set; }

        [JsonProperty("primaryFireAccuracy")] public long PrimaryFireAccuracy { get; set; }

        [JsonProperty("sentryTurretsKills")] public long SentryTurretsKills { get; set; }

        [JsonProperty("sentryTurretsKillsMostInGame")]
        public long SentryTurretsKillsMostInGame { get; set; }

        [JsonProperty("teleporterUptime")] public long TeleporterUptime { get; set; }

        [JsonProperty("teleporterUptimeBestInGame")]
        public long TeleporterUptimeBestInGame { get; set; }
    }

    public class Torbjorn
    {
        [JsonProperty("assists")] public DVaAssists Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public TorbjornHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class TorbjornHeroSpecific
    {
        [JsonProperty("armorPacksCreated")] public long ArmorPacksCreated { get; set; }

        [JsonProperty("armorPacksCreatedMostInGame")]
        public long ArmorPacksCreatedMostInGame { get; set; }

        [JsonProperty("moltenCoreKills")] public long MoltenCoreKills { get; set; }

        [JsonProperty("moltenCoreKillsMostInGame")]
        public long MoltenCoreKillsMostInGame { get; set; }

        [JsonProperty("torbjornKills")] public long TorbjornKills { get; set; }

        [JsonProperty("torbjornKillsMostInGame")]
        public long TorbjornKillsMostInGame { get; set; }

        [JsonProperty("turretsKills")] public long TurretsKills { get; set; }

        [JsonProperty("turretsKillsMostInGame")]
        public long TurretsKillsMostInGame { get; set; }
    }

    public class Tracer
    {
        [JsonProperty("assists")] public BastionAssists Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public TracerHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class TracerHeroSpecific
    {
        [JsonProperty("healthRecovered")] public long HealthRecovered { get; set; }

        [JsonProperty("healthRecoveredMostInGame")]
        public long HealthRecoveredMostInGame { get; set; }

        [JsonProperty("pulseBombsAttached")] public long PulseBombsAttached { get; set; }

        [JsonProperty("pulseBombsAttachedMostInGame")]
        public long PulseBombsAttachedMostInGame { get; set; }

        [JsonProperty("pulseBombsKills")] public long PulseBombsKills { get; set; }

        [JsonProperty("pulseBombsKillsMostInGame")]
        public long PulseBombsKillsMostInGame { get; set; }

        [JsonProperty("selfHealing")] public long SelfHealing { get; set; }

        [JsonProperty("selfHealingMostInGame")]
        public long SelfHealingMostInGame { get; set; }
    }

    public class Widowmaker
    {
        [JsonProperty("assists")] public HanzoAssists Assists { get; set; }

        [JsonProperty("average")] public AllHeroesAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public WidowmakerHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class WidowmakerHeroSpecific
    {
        [JsonProperty("scopedAccuracyBestInGame")]
        public string ScopedAccuracyBestInGame { get; set; }

        [JsonProperty("scopedCriticalHits")] public long ScopedCriticalHits { get; set; }

        [JsonProperty("scopedCriticalHitsMostInGame")]
        public long ScopedCriticalHitsMostInGame { get; set; }

        [JsonProperty("venomMineKills")] public long VenomMineKills { get; set; }

        [JsonProperty("venomMineKillsMostInGame")]
        public long VenomMineKillsMostInGame { get; set; }
    }

    public class FluffyWinston
    {
        [JsonProperty("assists")] public DVaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public WinstonHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public StickyMiscellaneous Miscellaneous { get; set; }
    }

    public class StickyMiscellaneous
    {
        [JsonProperty("jumpKills")] public long JumpKills { get; set; }

        [JsonProperty("meleeKills")] public long MeleeKills { get; set; }

        [JsonProperty("weaponKills")] public long WeaponKills { get; set; }
    }

    public class FluffyZarya
    {
        [JsonProperty("assists")] public IndigoAssists Assists { get; set; }

        [JsonProperty("average")] public TentacledAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public ZaryaHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public class IndigoAssists
    {
        [JsonProperty("defensiveAssists")] public long DefensiveAssists { get; set; }

        [JsonProperty("defensiveAssistsMostInGame")]
        public long DefensiveAssistsMostInGame { get; set; }

        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }

        [JsonProperty("offensiveAssistsMostInGame")]
        public long OffensiveAssistsMostInGame { get; set; }

        [JsonProperty("turretsDestroyed")] public long TurretsDestroyed { get; set; }
    }

    public class TentacledAverage
    {
        [JsonProperty("allDamageDone")] public long AllDamageDone { get; set; }

        [JsonProperty("averageEnergy")] public double AverageEnergy { get; set; }

        [JsonProperty("barrierDamageDone")] public long BarrierDamageDone { get; set; }

        [JsonProperty("damageBlocked")] public long DamageBlocked { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("defensiveAssists")] public long DefensiveAssists { get; set; }

        [JsonProperty("eliminations")] public long Eliminations { get; set; }

        [JsonProperty("eliminationsPerLife")] public double EliminationsPerLife { get; set; }

        [JsonProperty("finalBlows")] public long FinalBlows { get; set; }

        [JsonProperty("gravitonSurgeKills")] public long GravitonSurgeKills { get; set; }

        [JsonProperty("heroDamageDone")] public long HeroDamageDone { get; set; }

        [JsonProperty("highEnergyKills")] public long HighEnergyKills { get; set; }

        [JsonProperty("meleeFinalBlows")] public long MeleeFinalBlows { get; set; }

        [JsonProperty("objectiveKills")] public long ObjectiveKills { get; set; }

        [JsonProperty("objectiveTime")] public long ObjectiveTime { get; set; }

        [JsonProperty("offensiveAssists")] public long OffensiveAssists { get; set; }

        [JsonProperty("projectedBarriersApplied")]
        public long ProjectedBarriersApplied { get; set; }

        [JsonProperty("soloKills")] public long SoloKills { get; set; }

        [JsonProperty("timeSpentOnFire")] public long TimeSpentOnFire { get; set; }
    }

    public class FluffyZenyatta
    {
        [JsonProperty("assists")] public AnaAssists Assists { get; set; }

        [JsonProperty("average")] public PurpleAverage Average { get; set; }

        [JsonProperty("best")] public PurpleBest Best { get; set; }

        [JsonProperty("combat")] public PurpleCombat Combat { get; set; }

        [JsonProperty("deaths")] public Deaths Deaths { get; set; }

        [JsonProperty("heroSpecific")] public ZenyattaHeroSpecific HeroSpecific { get; set; }

        [JsonProperty("game")] public FluffyGame Game { get; set; }

        [JsonProperty("matchAwards")] public Awards MatchAwards { get; set; }

        [JsonProperty("miscellaneous")] public HeroSpecific Miscellaneous { get; set; }
    }

    public partial class OverwatchData
    {
        public static OverwatchData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<OverwatchData>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this OverwatchData self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            }
        };
    }
}
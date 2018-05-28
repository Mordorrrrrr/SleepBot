#region

using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace SoccerData
{
    public partial class SoccerData
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("round_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? RoundId { get; set; }

        [JsonProperty("pos", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pos { get; set; }

        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public GroupId? GroupId { get; set; }

        [JsonProperty("team1_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Team1Id { get; set; }

        [JsonProperty("team2_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Team2Id { get; set; }

        [JsonProperty("play_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? PlayAt { get; set; }

        [JsonProperty("postponed", NullValueHandling = NullValueHandling.Ignore)]
        public string Postponed { get; set; }

        [JsonProperty("play_at_v2", NullValueHandling = NullValueHandling.Ignore)]
        public string PlayAtV2 { get; set; }

        [JsonProperty("play_at_v3", NullValueHandling = NullValueHandling.Ignore)]
        public string PlayAtV3 { get; set; }

        [JsonProperty("ground_id", NullValueHandling = NullValueHandling.Ignore)]
        public string GroundId { get; set; }

        [JsonProperty("city_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CityId { get; set; }

        [JsonProperty("knockout", NullValueHandling = NullValueHandling.Ignore)]
        public string Knockout { get; set; }

        [JsonProperty("home", NullValueHandling = NullValueHandling.Ignore)]
        public string Home { get; set; }

        [JsonProperty("score1", NullValueHandling = NullValueHandling.Ignore)]
        public long? Score1 { get; set; }

        [JsonProperty("score2", NullValueHandling = NullValueHandling.Ignore)]
        public long? Score2 { get; set; }

        [JsonProperty("score1et", NullValueHandling = NullValueHandling.Ignore)]
        public GroupId? Score1Et { get; set; }

        [JsonProperty("score2et", NullValueHandling = NullValueHandling.Ignore)]
        public GroupId? Score2Et { get; set; }

        [JsonProperty("score1p", NullValueHandling = NullValueHandling.Ignore)]
        public string Score1P { get; set; }

        [JsonProperty("score2p", NullValueHandling = NullValueHandling.Ignore)]
        public string Score2P { get; set; }

        [JsonProperty("score1i", NullValueHandling = NullValueHandling.Ignore)]
        public string Score1I { get; set; }

        [JsonProperty("score2i", NullValueHandling = NullValueHandling.Ignore)]
        public string Score2I { get; set; }

        [JsonProperty("score1ii", NullValueHandling = NullValueHandling.Ignore)]
        public string Score1Ii { get; set; }

        [JsonProperty("score2ii", NullValueHandling = NullValueHandling.Ignore)]
        public string Score2Ii { get; set; }

        [JsonProperty("next_game_id", NullValueHandling = NullValueHandling.Ignore)]
        public string NextGameId { get; set; }

        [JsonProperty("prev_game_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PrevGameId { get; set; }

        [JsonProperty("winner", NullValueHandling = NullValueHandling.Ignore)]
        public long? Winner { get; set; }

        [JsonProperty("winner90", NullValueHandling = NullValueHandling.Ignore)]
        public long? Winner90 { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public struct GroupId
    {
        public long? Integer;
        public string String;

        public bool IsNull => Integer == null && String == null;
    }

    public partial class SoccerData
    {
        public static SoccerData[] FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SoccerData[]>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this SoccerData[] self)
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
                new GroupIdConverter(),
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            }
        };
    }

    internal class GroupIdConverter : JsonConverter
    {
        public override bool CanConvert(Type t)
        {
            return t == typeof(GroupId) || t == typeof(GroupId?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new GroupId {Integer = integerValue};
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new GroupId {String = stringValue};
            }

            throw new Exception("Cannot unmarshal type GroupId");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (GroupId) untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer);
                return;
            }

            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }

            throw new Exception("Cannot marshal type GroupId");
        }
    }
}
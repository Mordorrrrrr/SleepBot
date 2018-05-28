#region

using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace RoundsData
{
    public partial class RoundsData
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("title2", NullValueHandling = NullValueHandling.Ignore)]
        public string Title2 { get; set; }

        [JsonProperty("pos", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pos { get; set; }

        [JsonProperty("knockout", NullValueHandling = NullValueHandling.Ignore)]
        public string Knockout { get; set; }

        [JsonProperty("start_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartAt { get; set; }

        [JsonProperty("end_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EndAt { get; set; }

        [JsonProperty("auto", NullValueHandling = NullValueHandling.Ignore)]
        public string Auto { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public partial class RoundsData
    {
        public static RoundsData[] FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RoundsData[]>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this RoundsData[] self)
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
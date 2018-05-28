#region

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace AssData
{
    public partial class AssData
    {
        [JsonProperty("model")] public object Model { get; set; }

        [JsonProperty("preview")] public string Preview { get; set; }

        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("rank")] public long Rank { get; set; }

        [JsonProperty("author")] public object Author { get; set; }
    }

    public partial class AssData
    {
        public static AssData[] FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AssData[]>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this AssData[] self)
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
#region

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace PingData
{
    public partial class PingData
    {
        [JsonProperty("result")] public string Result { get; set; }

        [JsonProperty("time")] public string Time { get; set; }
    }

    public partial class PingData
    {
        public static PingData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PingData>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this PingData self)
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
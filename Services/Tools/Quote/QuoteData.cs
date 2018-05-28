#region

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace QuoteData
{
    public partial class QuoteData
    {
        [JsonProperty("quote", NullValueHandling = NullValueHandling.Ignore)]
        public string Quote { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }
    }

    public partial class QuoteData
    {
        public static QuoteData[] FromJson(string json)
        {
            return JsonConvert.DeserializeObject<QuoteData[]>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this QuoteData[] self)
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
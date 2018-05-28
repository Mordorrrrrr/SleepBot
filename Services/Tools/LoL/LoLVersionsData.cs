#region

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace LoLVerionsData
{
    public class LoLVersionsData
    {
        public static string[] FromJson(string json)
        {
            return JsonConvert.DeserializeObject<string[]>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this string[] self)
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
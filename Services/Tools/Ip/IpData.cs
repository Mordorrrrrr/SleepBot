#region

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace IpData
{
    public partial class IpData
    {
        [JsonProperty("statusCode")] public string StatusCode { get; set; }

        [JsonProperty("statusMessage")] public string StatusMessage { get; set; }

        [JsonProperty("ipAddress")] public string IpAddress { get; set; }

        [JsonProperty("countryCode")] public string CountryCode { get; set; }

        [JsonProperty("countryName")] public string CountryName { get; set; }

        [JsonProperty("regionName")] public string RegionName { get; set; }

        [JsonProperty("cityName")] public string CityName { get; set; }

        [JsonProperty("zipCode")] public string ZipCode { get; set; }

        [JsonProperty("latitude")] public string Latitude { get; set; }

        [JsonProperty("longitude")] public string Longitude { get; set; }

        [JsonProperty("timeZone")] public string TimeZone { get; set; }
    }

    public partial class IpData
    {
        public static IpData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<IpData>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this IpData self)
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
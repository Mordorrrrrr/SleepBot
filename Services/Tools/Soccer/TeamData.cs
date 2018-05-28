#region

using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace TeamData
{
    public partial class TeamData
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("title2", NullValueHandling = NullValueHandling.Ignore)]
        public string Title2 { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("synonyms", NullValueHandling = NullValueHandling.Ignore)]
        public string Synonyms { get; set; }

        [JsonProperty("country_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? CountryId { get; set; }

        [JsonProperty("city_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CityId { get; set; }

        [JsonProperty("club", NullValueHandling = NullValueHandling.Ignore)]
        public string Club { get; set; }

        [JsonProperty("since", NullValueHandling = NullValueHandling.Ignore)]
        public string Since { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty("web", NullValueHandling = NullValueHandling.Ignore)]
        public string Web { get; set; }

        [JsonProperty("assoc_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AssocId { get; set; }

        [JsonProperty("national", NullValueHandling = NullValueHandling.Ignore)]
        public string National { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public partial class TeamData
    {
        public static TeamData[] FromJson(string json)
        {
            return JsonConvert.DeserializeObject<TeamData[]>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this TeamData[] self)
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
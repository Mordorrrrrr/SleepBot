#region

using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace UrbanData
{
    public partial class UrbanData
    {
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Tags { get; set; }

        [JsonProperty("result_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ResultType { get; set; }

        [JsonProperty("list", NullValueHandling = NullValueHandling.Ignore)]
        public UrbanList[] UrbanList { get; set; }

        [JsonProperty("sounds", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Sounds { get; set; }
    }

    public class UrbanList
    {
        [JsonProperty("definition", NullValueHandling = NullValueHandling.Ignore)]
        public string Definition { get; set; }

        [JsonProperty("permalink", NullValueHandling = NullValueHandling.Ignore)]
        public string Permalink { get; set; }

        [JsonProperty("thumbs_up", NullValueHandling = NullValueHandling.Ignore)]
        public long? ThumbsUp { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        [JsonProperty("word", NullValueHandling = NullValueHandling.Ignore)]
        public string Word { get; set; }

        [JsonProperty("defid", NullValueHandling = NullValueHandling.Ignore)]
        public long? Defid { get; set; }

        [JsonProperty("current_vote", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentVote { get; set; }

        [JsonProperty("written_on", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? WrittenOn { get; set; }

        [JsonProperty("example", NullValueHandling = NullValueHandling.Ignore)]
        public string Example { get; set; }

        [JsonProperty("thumbs_down", NullValueHandling = NullValueHandling.Ignore)]
        public long? ThumbsDown { get; set; }
    }

    public partial class UrbanData
    {
        public static UrbanData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UrbanData>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this UrbanData self)
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
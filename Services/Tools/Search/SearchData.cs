#region

using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace SearchData
{
    public partial class SearchData
    {
        [JsonProperty("results")] public Result[] Results { get; set; }

        [JsonProperty("query")] public string Query { get; set; }

        [JsonProperty("suggestions")] public object[] Suggestions { get; set; }

        [JsonProperty("count")] public long Count { get; set; }

        [JsonProperty("start")] public long Start { get; set; }

        [JsonProperty("length")] public long Length { get; set; }

        [JsonProperty("time")] public string Time { get; set; }
    }

    public class Result
    {
        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("kwic")] public string Kwic { get; set; }

        [JsonProperty("content")] public Content Content { get; set; }

        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("iurl")] public string Iurl { get; set; }

        [JsonProperty("domain")] public string Domain { get; set; }

        [JsonProperty("author")] public string Author { get; set; }

        [JsonProperty("news")] public bool News { get; set; }

        [JsonProperty("votes")] public string Votes { get; set; }

        [JsonProperty("date")] public long Date { get; set; }

        [JsonProperty("related")] public object[] Related { get; set; }
    }

    public enum Content
    {
        Empty
    }

    public partial class SearchData
    {
        public static SearchData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SearchData>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this SearchData self)
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
                new ContentConverter(),
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            }
        };
    }

    internal class ContentConverter : JsonConverter
    {
        public override bool CanConvert(Type t)
        {
            return t == typeof(Content) || t == typeof(Content?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "") return Content.Empty;
            throw new Exception("Cannot unmarshal type Content");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Content) untypedValue;
            if (value == Content.Empty)
            {
                serializer.Serialize(writer, "");
                return;
            }

            throw new Exception("Cannot marshal type Content");
        }
    }
}
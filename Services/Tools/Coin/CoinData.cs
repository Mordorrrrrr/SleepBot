#region

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace CoinData
{
    public partial class CoinData
    {
        [JsonProperty("altCap")] public double AltCap { get; set; }

        [JsonProperty("bitnodesCount")] public long BitnodesCount { get; set; }

        [JsonProperty("btcCap")] public double BtcCap { get; set; }

        [JsonProperty("btcPrice")] public double BtcPrice { get; set; }

        [JsonProperty("dom")] public double Dom { get; set; }

        [JsonProperty("totalCap")] public double TotalCap { get; set; }

        [JsonProperty("volumeAlt")] public double VolumeAlt { get; set; }

        [JsonProperty("volumeBtc")] public double VolumeBtc { get; set; }

        [JsonProperty("volumeTotal")] public double VolumeTotal { get; set; }

        [JsonProperty("id")] public string CoinDataId { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("_id")] public string Id { get; set; }

        [JsonProperty("price_btc")] public long PriceBtc { get; set; }

        [JsonProperty("price_eth")] public double PriceEth { get; set; }

        [JsonProperty("price_ltc")] public double PriceLtc { get; set; }

        [JsonProperty("price_zec")] public double PriceZec { get; set; }

        [JsonProperty("price_eur")] public double PriceEur { get; set; }

        [JsonProperty("price_usd")] public double PriceUsd { get; set; }

        [JsonProperty("market_cap")] public double MarketCap { get; set; }

        [JsonProperty("cap24hrChange")] public double Cap24HrChange { get; set; }

        [JsonProperty("display_name")] public string DisplayName { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("supply")] public long Supply { get; set; }

        [JsonProperty("volume")] public long Volume { get; set; }

        [JsonProperty("price")] public double Price { get; set; }

        [JsonProperty("vwap_h24")] public double VwapH24 { get; set; }

        [JsonProperty("rank")] public long Rank { get; set; }

        [JsonProperty("alt_name")] public string AltName { get; set; }
    }

    public partial class CoinData
    {
        public static CoinData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CoinData>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this CoinData self)
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

namespace Coins
{
    public class Coins
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
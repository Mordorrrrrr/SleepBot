#region

using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace DiscordBOT.Services.External
{
    public static class ConfigurationService
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer();

        public static void Initialize()
        {
            Serializer.Converters.Add(new JavaScriptDateTimeConverter());
            Serializer.NullValueHandling = NullValueHandling.Ignore;
        }

        public static async Task<ConcurrentDictionary<string, string>> LoadConfig(string name = @"config.json")
        {
            if (!File.Exists(name)) return null;

            using (var streamReader = File.OpenText(name))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    return Serializer.Deserialize<ConcurrentDictionary<string, string>>(jsonReader);
                }
            }
        }
    }
}
using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class AssetBundle
    {
        [JsonProperty("maker")]
        public Account? Maker { get; set; }

        [JsonProperty("slug")]
        public string? Slug { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("assets")]
        public List<Asset>? Assets { get; set; }
    }
}

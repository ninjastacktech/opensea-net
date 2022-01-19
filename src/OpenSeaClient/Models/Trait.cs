using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class Trait
    {
        [JsonProperty("trait_type")]
        public string? TraitType { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }

        [JsonProperty("display_type")]
        public string? DisplayType { get; set; }

        [JsonProperty("max_value")]
        public string? MaxValue { get; set; }

        [JsonProperty("trait_count")]
        public long? TraitCount { get; set; }

        [JsonProperty("order")]
        public string? Order { get; set; }
    }
}

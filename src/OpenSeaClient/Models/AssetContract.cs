using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class AssetContract
    {
        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("asset_contract_type")]
        public string? AssetContractType { get; set; }

        [JsonProperty("schema_name")]
        public string? SchemaName { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("symbol")]
        public string? Symbol { get; set; }

        [JsonProperty("image_url")]
        public string? ImageUrl { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("external_link")]
        public string? ExternalLink { get; set; }
    }
}

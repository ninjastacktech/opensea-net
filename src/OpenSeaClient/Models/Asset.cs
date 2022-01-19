using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class Asset
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("token_id")]
        public string? TokenId { get; set; }

        [JsonProperty("num_sales")]
        public long NumSales { get; set; }

        [JsonProperty("image_url")]
        public string? ImageUrl { get; set; }

        [JsonProperty("image_preview_url")]
        public string? ImagePreviewUrl { get; set; }

        [JsonProperty("image_thumbnail_url")]
        public string? ImageThumbnailUrl { get; set; }

        [JsonProperty("animation_url")]
        public string? AnimationUrl { get; set; }

        [JsonProperty("animation_original_url")]
        public string? AnimationOriginalUrl { get; set; }

        [JsonProperty("background_url")]
        public string? BackgroundUrl { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("external_link")]
        public string? ExternalLink { get; set; }

        [JsonProperty("token_metadata")]
        public string? TokenMetadata { get; set; }

        [JsonProperty("permalink")]
        public string? Permalink { get; set; }

        [JsonProperty("traits")]
        public List<Trait>? Traits { get; set; }

        [JsonProperty("asset_contract")]
        public AssetContract? AssetContract { get; set; }

        [JsonProperty("collection")]
        public Collection? Collection { get; set; }
    }
}

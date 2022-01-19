using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class Collection
    {
        [JsonProperty("stats")]
        public CollectionStats? Stats { get; set; }

        [JsonProperty("banner_image_url")]
        public string? BannerImageUrl { get; set; }

        [JsonProperty("chat_rul")]
        public string? ChatUrl { get; set; }

        [JsonProperty("created_date")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("default_to_fiat")]
        public bool DefaultToFiat { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("dev_buyer_fee_basis_points")]
        public string? DevBuyerFeeBasisPoints { get; set; }

        [JsonProperty("dev_seller_fee_basis_points")]
        public string? DevSellerFeeBasisPoints { get; set; }

        [JsonProperty("discord_url")]
        public string? DiscordUrl { get; set; }

        [JsonProperty("external_url")]
        public string? ExternalUrl { get; set; }

        [JsonProperty("featured")]
        public bool Featured { get; set; }

        [JsonProperty("featured_image_url")]
        public string? FeaturedImageUrl { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("safelist_request_status")]
        public string? SafelistRequestStatus { get; set; }

        [JsonProperty("image_url")]
        public string? ImageUrl { get; set; }

        [JsonProperty("is_subject_to_whitelist")]
        public bool IsSubjectToWhitelist { get; set; }

        [JsonProperty("large_image_url")]
        public string? LargeImageUrl { get; set; }

        [JsonProperty("medium_username")]
        public string? MediumUsername { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("only_proxied_transfers")]
        public bool OnlyProxiedTransfers { get; set; }

        [JsonProperty("opensea_buyer_fee_basis_points")]
        public string? OpenSeaBuyerFeeBasisPoints { get; set; }

        [JsonProperty("opensea_seller_fee_basis_points")]
        public string? OpenSeaSellerFeeBasisPoints { get; set; }

        [JsonProperty("payout_address")]
        public string? PayoutAddress { get; set; }

        [JsonProperty("require_email")]
        public bool RequireEmail { get; set; }

        [JsonProperty("short_description")]
        public string? ShortDescription { get; set; }

        [JsonProperty("slug")]
        public string? Slug { get; set; }

        [JsonProperty("telegram_url")]
        public string? TelegramUrl { get; set; }

        [JsonProperty("twitter_username")]
        public string? TwitterUsername { get; set; }

        [JsonProperty("instagram_username")]
        public string? InstagramUsername { get; set; }

        [JsonProperty("wiki_url")]
        public string? WikiUrl { get; set; }
    }
}

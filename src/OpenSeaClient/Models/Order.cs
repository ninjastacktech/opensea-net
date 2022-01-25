using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class Order
    {
        [JsonProperty("asset")]
        public Asset? Asset { get; set; }

        [JsonProperty("created_date")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("closing_date")]
        public DateTime? ClosingDate { get; set; }

        [JsonProperty("expiration_time")]
        public long? ExpirationTime { get; set; }

        [JsonProperty("listing_time")]
        public long? ListingTime { get; set; }

        [JsonProperty("order_hash")]
        public string? OrderHash { get; set; }

        [JsonProperty("exchange")]
        public string? Exchange { get; set; }

        [JsonProperty("maker")]
        public Account? Maker { get; set; }

        [JsonProperty("taker")]
        public Account? Taker { get; set; }

        [JsonProperty("fee_recipient")]
        public Account? FeeRecipient { get; set; }

        [JsonProperty("current_price")]
        public string? CurrentPrice { get; set; }

        public decimal? CurrentPriceEth { get; set; }

        [JsonProperty("current_bounty")]
        public string? CurrentBounty { get; set; }

        [JsonProperty("bounty_multiple")]
        public string? BountyMultiple { get; set; }

        [JsonProperty("maker_relayer_fee")]
        public string? MakerRelayerFee { get; set; }

        [JsonProperty("taker_relayer_fee")]
        public string? TakerRelayerFee { get; set; }

        [JsonProperty("maker_protocol_fee")]
        public string? MakerProtocolFee { get; set; }

        [JsonProperty("taker_protocol_fee")]
        public string? TakerProtocolFee { get; set; }

        [JsonProperty("maker_referrer_fee")]
        public string? MakerReferrerFee { get; set; }

        [JsonProperty("fee_method")]
        public int? FeeMethod { get; set; }

        [JsonProperty("side")]
        public int? Side { get; set; }

        [JsonProperty("sale_kind")]
        public int? SaleKind { get; set; }

        [JsonProperty("target")]
        public string? Target { get; set; }

        [JsonProperty("how_to_call")]
        public int? HowToCall { get; set; }

        [JsonProperty("calldata")]
        public string? Calldata { get; set; }

        [JsonProperty("replacement_pattern")]
        public string? ReplacementPattern { get; set; }

        [JsonProperty("static_target")]
        public string? StaticTarget { get; set; }

        [JsonProperty("static_extradata")]
        public string? StaticExtradata { get; set; }

        [JsonProperty("payment_token")]
        public string? PaymentToken { get; set; }

        [JsonProperty("base_price")]
        public string? BasePrice { get; set; }

        [JsonProperty("extra")]
        public string? Extra { get; set; }

        [JsonProperty("quantity")]
        public string? Quantity { get; set; }

        [JsonProperty("salt")]
        public string? Salt { get; set; }

        [JsonProperty("v")]
        public long? V { get; set; }

        [JsonProperty("r")]
        public string? R { get; set; }

        [JsonProperty("s")]
        public string? S { get; set; }

        [JsonProperty("approved_on_chain")]
        public bool? ApprovedOnChain { get; set; }

        [JsonProperty("cancelled")]
        public bool? Cancelled { get; set; }

        [JsonProperty("finalized")]
        public bool? Finalized { get; set; }

        [JsonProperty("marked_invalid")]
        public bool? MarkedInvalid { get; set; }

        [JsonProperty("prefixed_hash")]
        public string? PrefixedHash { get; set; }
    }
}

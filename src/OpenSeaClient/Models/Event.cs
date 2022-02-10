using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class Event
    {
        [JsonProperty("event_type")]
        public string? EventType { get; set; }

        [JsonProperty("asset")]
        public Asset? Asset { get; set; }

        [JsonProperty("asset_bundle")]
        public string? AssetBundle { get; set; }

        [JsonProperty("created_date")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("from_account")]
        public Account? FromAccount { get; set; }

        [JsonProperty("to_account")]
        public Account? ToAccount { get; set; }

        [JsonProperty("seller")]
        public Account? Seller { get; set; }

        [JsonProperty("winner_account")]
        public Account? WinnerAccount { get; set; }

        [JsonProperty("is_private")]
        public bool? IsPrivate { get; set; }

        //[JsonProperty("payment_token")]
        //public string? PaymentToken { get; set; }

        [JsonProperty("total_price")]
        public string? TotalPrice { get; set; }

        public decimal? TotalPriceEth { get; set; }

        [JsonProperty("quantity")]
        public string? Quantity { get; set; }

        [JsonProperty("collection_slug")]
        public string? CollectionSlug { get; set; }

        [JsonProperty("contract_address")]
        public string? ContractAddress { get; set; }

        [JsonProperty("transaction")]
        public Transaction? Transaction { get; set; }
    }
}

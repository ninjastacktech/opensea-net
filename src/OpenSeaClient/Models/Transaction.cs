using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class Transaction
    {
        [JsonProperty("block_hash")]
        public string? BlockHash { get; set; }

        [JsonProperty("block_number")]
        public string? BlockNumber { get; set; }

        [JsonProperty("from_account")]
        public Account? FromAccount { get; set; }

        [JsonProperty("to_account")]
        public Account? ToAccount { get; set; }

        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("transaction_hash")]
        public string? TransactionHash { get; set; }

        [JsonProperty("transaction_index")]
        public string? TransactionIndex { get; set; }
    }
}

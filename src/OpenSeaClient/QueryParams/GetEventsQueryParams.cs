namespace OpenSeaClient
{
    public class GetEventsQueryParams
    {
        /// <summary>
        /// The NFT contract address for the assets for which to show events.
        /// </summary>
        public string? AssetContractAddress { get; set; }

        /// <summary>
        /// Limit responses to members of a collection.
        /// Case sensitive and must match the collection slug exactly.
        /// Will return all assets from all contracts in a collection.
        /// </summary>
        public string? CollectionSlug { get; set; }

        /// <summary>
        /// The token's id to optionally filter by.
        /// </summary>
        public string? TokenId { get; set; }

        /// <summary>
        /// A user account's wallet address to filter for events on an account.
        /// </summary>
        public string? AccountAddress { get; set; }

        /// <summary>
        /// The event type to filter.
        /// Can be created for new auctions, successful for sales, cancelled, bid_entered, bid_withdrawn, transfer, or approve.
        /// </summary>
        public string? EventType { get; set; }

        /// <summary>
        /// Restrict to events on OpenSea auctions. Can be true or false.
        /// </summary>
        public bool? OnlyOpenSea { get; set; }

        /// <summary>
        /// Filter by an auction type.
        /// Can be english for English Auctions, dutch for fixed-price and declining-price sell orders (Dutch Auctions), or min-price for CryptoPunks bidding auctions.
        /// </summary>
        public string? AuctionType { get; set; }

        /// <summary>
        /// Offset.
        /// </summary>
        public long? Offset { get; set; }

        /// <summary>
        /// Limit. Defaults to 20, capped at 50.
        /// </summary>
        public long? Limit { get; set; }

        /// <summary>
        /// Only show events listed before this timestamp. Seconds since the Unix epoch.
        /// </summary>
        public long? OccuredBefore { get; set; }

        /// <summary>
        /// Only show events listed after this timestamp. Seconds since the Unix epoch..
        /// </summary>
        public long? OccuredAfter { get; set; }

        internal List<(string, string)> ToQueryParameters()
        {
            var queryParams = new List<(string, string)>();

            if (AccountAddress != null)
            {
                queryParams.Add(("account_address", AccountAddress));
            }

            if (TokenId != null)
            {
                queryParams.Add(("token_id", TokenId));
            }

            if (AssetContractAddress != null)
            {
                queryParams.Add(("asset_contract_address", AssetContractAddress));
            }

            if (AssetContractAddress != null)
            {
                queryParams.Add(("asset_contract_address", AssetContractAddress));
            }

            if (EventType != null)
            {
               queryParams.Add(("event_type", EventType));
            }

            if (OnlyOpenSea != null)
            {
                queryParams.Add(("only_opensea", OnlyOpenSea.Value.ToString().ToLower()));
            }

            if (Offset != null)
            {
                queryParams.Add(("offset", Offset?.ToString() ?? "0"));
            }

            if (Limit != null)
            {
                queryParams.Add(("limit", Limit?.ToString() ?? "20"));
            }

            if (CollectionSlug != null)
            {
                queryParams.Add(("collection", CollectionSlug));
            }

            if (AuctionType != null)
            {
                queryParams.Add(("auction_type", AuctionType));
            }

            if (OccuredAfter != null)
            {
                queryParams.Add(("occurred_after", OccuredAfter.Value.ToString()));
            }

            if (OccuredBefore != null)
            {
                queryParams.Add(("auction_before", OccuredBefore.Value.ToString()));
            }

            return queryParams;
        }
    }
}

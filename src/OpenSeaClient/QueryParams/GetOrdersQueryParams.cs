namespace OpenSeaClient
{
    public class GetOrdersQueryParams
    {
        /// <summary>
        /// Filter by smart contract address for the asset category. Needs to be defined together with token_id or token_ids.
        /// </summary>
        public string? AssetContractAddress { get; set; }

        /// <summary>
        /// Filter by the address of the smart contract of the payment token that is accepted or offered by the order.
        /// </summary>
        public string? PaymentTokenAddress { get; set; }

        /// <summary>
        /// Filter by the order maker's wallet address.
        /// </summary>
        public string? Maker { get; set; }

        /// <summary>
        /// Filter by the order taker's wallet address. Orders open for any taker have the null address as their taker.
        /// </summary>
        public string? Taker { get; set; }

        /// <summary>
        /// Filter by the asset owner's wallet address.
        /// </summary>
        public string? OwnerAddress { get; set; }

        /// <summary>
        /// When "true", only show English Auction sell orders, which wait for the highest bidder. When "false", exclude those.
        /// </summary>
        public bool? IsEnglishAuction { get; set; }

        /// <summary>
        /// Only show orders for bundles of assets
        /// </summary>
        public bool Bundled { get; set; }

        /// <summary>
        /// Include orders on bundles where all assets in the bundle share the address provided in asset_contract_address or where the bundle's maker is the address provided in owner.
        /// </summary>
        public bool IncludeBundled { get; set; }

        /// <summary>
        /// Only show orders listed after this timestamp. Seconds since the Unix epoch.
        /// </summary>
        public long? ListedAfter { get; set; }

        /// <summary>
        /// Only show orders listed before this timestamp. Seconds since the Unix epoch.
        /// </summary>
        public long? ListedBefore { get; set; }

        /// <summary>
        /// Filter by the token ID of the order's asset. Needs to be defined together with asset_contract_address.
        /// </summary>
        public string? TokenId { get; set; }

        /// <summary>
        /// Filter by a list of token IDs for the order's asset. Needs to be defined together with asset_contract_address.
        /// </summary>
        public List<string>? TokenIds { get; set; }

        /// <summary>
        /// Filter by the side of the order. 0 for buy orders and 1 for sell orders.
        /// </summary>
        public int? Side { get; set; }

        /// <summary>
        /// Filter by the kind of sell order. 0 for fixed-price sales or min-bid auctions, and 1 for declining-price Dutch Auctions.
        /// NOTE: use only_english=true for filtering for only English Auctions.
        /// </summary>
        public int? SaleKind { get; set; }

        /// <summary>
        /// Offset.
        /// </summary>
        public long? Offset { get; set; }

        /// <summary>
        /// Limit. Defaults to 20, capped at 50.
        /// </summary>
        public long? Limit { get; set; }

        /// <summary>
        /// How to sort the orders.
        /// Can be created_date for when they were made, or eth_price to see the lowest-priced orders first (converted to their ETH values).
        /// eth_price is only supported when asset_contract_address and token_id are also defined.
        /// </summary>
        public OrderOrdersBy? OrderBy { get; set; }

        /// <summary>
        /// Can be asc or desc for ascending or descending sort.
        /// For example, to see the cheapest orders, do order_direction asc and order_by eth_price.
        /// </summary>
        public OrderDirection? OrderDirection { get; set; }

        internal List<(string, string)> ToQueryParameters()
        {
            var queryParams = new List<(string, string)>();

            if (AssetContractAddress != null)
            {
                queryParams.Add(("asset_contract_address", AssetContractAddress));
            }

            if (PaymentTokenAddress != null)
            {
                queryParams.Add(("payment_token_address", PaymentTokenAddress));
            }

            if (Maker != null)
            {
                queryParams.Add(("maker", Maker));
            }

            if (Taker != null)
            {
                queryParams.Add(("taker", Taker));
            }

            if (OwnerAddress != null)
            {
                queryParams.Add(("owner", OwnerAddress));
            }

            if (IsEnglishAuction != null)
            {
                queryParams.Add(("is_english", IsEnglishAuction.Value.ToString().ToLower()));
            }

            queryParams.Add(("bundled", Bundled.ToString().ToLower()));

            queryParams.Add(("include_bundled", IncludeBundled.ToString().ToLower()));

            if (ListedAfter != null)
            {
                queryParams.Add(("listed_after", ListedAfter.Value.ToString()));
            }

            if (ListedBefore != null)
            {
                queryParams.Add(("listed_before", ListedBefore.Value.ToString()));
            }

            if (TokenId != null)
            {
                queryParams.Add(("token_id", TokenId));
            }

            if (TokenIds != null)
            {
                foreach (var tokenId in TokenIds)
                {
                    queryParams.Add(("token_ids", tokenId));
                }
            }

            if (Side != null)
            {
                queryParams.Add(("side", Side.Value.ToString()));
            }

            if (SaleKind != null)
            {
                queryParams.Add(("sale_kind", SaleKind.Value.ToString()));
            }

            if (Offset != null)
            {
                queryParams.Add(("offset", Offset.Value.ToString()));
            }

            if (Limit != null)
            {
                queryParams.Add(("limit", Limit.Value.ToString()));
            }

            if (OrderBy != null)
            {
                var orderByString = OrderBy.GetDescription();

                if (orderByString != null)
                {
                    queryParams.Add(("order_by", orderByString));
                }
            }

            if (OrderDirection != null)
            {
                var orderDirectionString = OrderDirection.GetDescription();

                if (orderDirectionString != null)
                {
                    queryParams.Add(("order_direction", orderDirectionString));
                }
            }

            return queryParams;
        }
    }
}

namespace OpenSeaClient
{
    public class GetAssetsQueryParams
    {
        /// <summary>
        /// The address of the owner of the assets.
        /// </summary>
        public string? OwnerAddress { get; set; }

        /// <summary>
        /// An array of token IDs to search for (e.g. ?token_ids=1&token_ids=209).
        /// Will return a list of assets with token_id matching any of the IDs in this array.
        /// </summary>
        public List<string>? TokenIds { get; set; }

        /// <summary>
        /// The NFT contract address for the assets.
        /// </summary>
        public string? AssetContractAddress { get; set; }

        /// <summary>
        /// An array of contract addresses to search for (e.g. ?asset_contract_addresses=0x1...&asset_contract_addresses=0x2...).
        /// Will return a list of assets with contracts matching any of the addresses in this array.
        /// If "token_ids" is also specified, then it will only return assets that match each (address, token_id) pairing, respecting order.
        /// </summary>
        public List<string>? AssetContractAddresses { get; set; }

        /// <summary>
        /// How to order the assets returned. By default, the API returns the fastest ordering.
        /// Options you can set are sale_date (the last sale's transaction's timestamp), sale_count (number of sales), and sale_price (the last sale's total_price).
        /// </summary>
        public OrderAssetsBy? OrderBy { get; set; }

        /// <summary>
        /// Can be asc for ascending or desc for descending.
        /// </summary>
        public OrderDirection? OrderDirection { get; set; }

        /// <summary>
        /// Offset.
        /// </summary>
        public long? Offset { get; set; }

        /// <summary>
        /// Limit. Defaults to 20, capped at 50.
        /// </summary>
        public long? Limit { get; set; }

        /// <summary>
        /// Limit responses to members of a collection.
        /// Case sensitive and must match the collection slug exactly.
        /// Will return all assets from all contracts in a collection.
        /// </summary>
        public string? CollectionSlug { get; set; }

        internal List<(string, string)> ToQueryParameters()
        {
            var queryParams = new List<(string, string)>();

            if (OwnerAddress != null)
            {
                queryParams.Add(("owner", OwnerAddress));
            }

            if (TokenIds != null)
            {
                foreach (var tokenId in TokenIds)
                {
                    queryParams.Add(("token_ids", tokenId));
                }
            }

            if (AssetContractAddress != null)
            {
                queryParams.Add(("asset_contract_address", AssetContractAddress));
            }

            if (AssetContractAddresses != null)
            {
                foreach (var assetContractAddress in AssetContractAddresses)
                {
                    queryParams.Add(("asset_contract_addresses", assetContractAddress));
                }
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

            if (Offset != null)
            {
                queryParams.Add(("offset", Offset.Value.ToString()));
            }

            if (Limit != null)
            {
                queryParams.Add(("limit", Limit.Value.ToString()));
            }

            if (CollectionSlug != null)
            {
                queryParams.Add(("collection", CollectionSlug));
            }

            return queryParams;
        }
    }
}

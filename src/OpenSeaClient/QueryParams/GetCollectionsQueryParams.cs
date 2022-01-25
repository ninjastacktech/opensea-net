namespace OpenSeaClient
{
    public class GetCollectionsQueryParams
    {
        /// <summary>
        /// A wallet address. If specified, will return collections where the owner owns at least one asset belonging to smart contracts in the collection.
        /// The number of assets the account owns is shown as owned_asset_count for each collection.
        /// </summary>
        public string? AssetOwner { get; set; }

        /// <summary>
        /// For pagination. Number of contracts offset from the beginning of the result list.
        /// </summary>
        public long? Offset { get; set; }

        /// <summary>
        /// For pagination. Maximum number of contracts to return.
        /// </summary>
        public long? Limit { get; set; }

        internal List<(string, string)> ToQueryParameters()
        {
            var queryParams = new List<(string, string)>();

            if (AssetOwner != null)
            {
                queryParams.Add(("asset_owner", AssetOwner));
            }

            if (Offset != null)
            {
                queryParams.Add(("offset", Offset.Value.ToString()));
            }

            if (Limit != null)
            {
                queryParams.Add(("limit", Limit.Value.ToString()));
            }

            return queryParams;
        }
    }
}

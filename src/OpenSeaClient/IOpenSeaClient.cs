namespace OpenSeaClient
{
    public interface IOpenSeaClient
    {
        /// <summary>
        /// To retrieve assets from our API, call the /assets endpoint with the desired filter parameters.
        /// Please Note: this API endpoint requires an API key in order to use. Please fill out the API request form to obtain one.
        /// Auctions created on OpenSea don't use an escrow contract, which enables gas-free auctions and allows users to retain ownership of their items while they're on sale.
        /// So this is just a heads up in case you notice some assets from opensea.io not appearing in the API.
        /// </summary>
        /// <param name="queryParams"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<List<Asset>?> GetAssetsAsync(GetAssetsQueryParams? queryParams = null, CancellationToken ct = default);

        /// <summary>
        /// Used to fetch more in-depth information about an individual asset.
        /// To retrieve an individual from our API, call the /asset endpoint with the address of the asset's contract and the token id.
        /// The endpoint will return an Asset Object.
        /// </summary>
        /// <param name="assetContractAddress"></param>
        /// <param name="tokenId"></param>
        /// <param name="ownerAddress"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Asset?> GetAssetAsync(string assetContractAddress, string tokenId, string? ownerAddress = null, CancellationToken ct = default);

        /// <summary>
        /// Used to fetch more in-depth information about an contract asset.
        /// </summary>
        /// <param name="assetContractAddress"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<AssetContract?> GetAssetContractAsync(string assetContractAddress, CancellationToken ct = default);

        /// <summary>
        /// Use this endpoint to fetch collections on OpenSea.
        /// The /collections endpoint provides a list of all the collections supported and vetted by OpenSea.
        /// To include all collections relevant to a user (including non-whitelisted ones), set the owner param.
        /// Each collection in the returned area has an attribute called primary_asset_contracts with info about the smart contracts belonging to that collection.
        /// For example, ERC-1155 contracts maybe have multiple collections all referencing the same contract, but many ERC-721 contracts may all belong to the same collection (dapp).
        /// You can also use this endpoint to find which dapps an account uses, and how many items they own in each - all in one API call!
        /// </summary>
        /// <param name="queryParams"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<List<Collection>?> GetCollectionsAsync(GetCollectionsQueryParams? queryParams = null, CancellationToken ct = default);

        /// <summary>
        /// Used for retrieving more in-depth information about individual collections, including real time statistics like floor price.
        /// </summary>
        /// <param name="collectionSlug"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Collection?> GetCollectionAsync(string collectionSlug, CancellationToken ct = default);

        /// <summary>
        /// Use this endpoint to fetch stats for a specific collection, including realtime floor price statistics.
        /// </summary>
        /// <param name="collectionSlug"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<CollectionStats?> GetCollectionStatsAsync(string collectionSlug, CancellationToken ct = default);
    }
}

using OpenSeaClient;

var client = new OpenSeaHttpClient();

var asset = await client.GetAssetAsync("0x6dc6001535e15b9def7b0f6a20a2111dfa9454e2", "2859");
//var data = await client.GetCollectionAsync("metahero-generative");
//var assetContract = await client.GetAssetContractAsync("0x7deb7bce4d360ebe68278dee6054b882aa62d19c");
//var assets = await client.GetAssetsAsync(new GetAssetsQueryParams
//{
//    CollectionSlug = "planetdaos",
//    Limit = 5,
//    Offset = 0,
//    OrderBy = OrderBy.SalePrice,
//    OrderDirection = OrderDirection.Asc,
//});
//var collections = await client.GetCollectionsAsync(new GetCollectionsQueryParams
//{
//    AssetOwner = "",
//    Limit = 20,
//});

var a = 2;
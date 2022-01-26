using OpenSeaClient;

var client = new OpenSeaHttpClient(apiKey: "");

// Get assets in batches of 50 with 1s delay between API calls to avoid throttling:

var queryParams = new GetAssetsQueryParams
{
    CollectionSlug = "niftydegen",
};
var count = 0;
var limit = 50;
var it = 0;

var assetsList = new List<Asset>();

do
{
    queryParams.Offset = limit * it;
    queryParams.Limit = limit;

    var assets = await client.GetAssetsAsync(queryParams);

    if (assets != null)
    {
        if (assets.Count > 0)
        {
            assetsList.AddRange(assets);
        }
    }
    else
    {
        break;
    }

    await Task.Delay(1000);
}
while (count == 50);

// Get the price of a token's sale order:

var tokenId = "697";
var contractAddress = "0x986aea67c7d6a15036e18678065eb663fc5be883";

var orders = await client.GetOrdersAsync(new GetOrdersQueryParams
{
    AssetContractAddress = contractAddress,
    TokenId = tokenId,
    Side = 1,
    SaleKind = 0,
});

if (orders?.Any() == true)
{
    var order = orders.Where(x => x.Cancelled == false).OrderBy(x => x.CurrentPriceEth).FirstOrDefault();

    if (order != null)
    {
        Console.WriteLine($"Token {tokenId} has a sell order of {order.CurrentPriceEth} ETH");
    }
}

Console.ReadLine();

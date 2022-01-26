# opensea-net
.NET 6 C# SDK for the OpenSea marketplace API.

The API docs can be found here: https://docs.opensea.io/reference/api-overview

[![NuGet](https://img.shields.io/nuget/v/OpenSeaClient)](https://www.nuget.org/packages/OpenSeaClient/) 

# snippets

### Get assets in batches of 50 with 1s delay between API calls to avoid throttling:
```C#
var client = new OpenSeaHttpClient(apiKey: "0066a183992746f6bbdb386493edbf10");

var queryParams = new GetAssetsQueryParams
{
    CollectionSlug = collectionSlug,
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

    await Task.Delay(taskDelayMs);
}
while (count == 50);
```

### Get the price of a token's sale order:
Note that the listing price of an asset is equal to the currentPrice of the lowest valid sell order on the asset. 
Users can lower their listing price without invalidating previous sell orders, so all get shipped down until they're canceled, or one is fulfilled.
```C#
var client = new OpenSeaHttpClient(apiKey: "0066a183992746f6bbdb386493edbf10");

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
        Console.WriteLine($"Token {token} has a sell order of {order.CurrentPriceEth} ETH");                   
    }
}
```


---

### MIT License



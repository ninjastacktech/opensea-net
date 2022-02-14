<br>

<img src="https://camo.githubusercontent.com/57cfb2f91adf5c2b206607d801cbf30710614fd4170f05352c75a2d351417ea4/68747470733a2f2f73746f726167652e676f6f676c65617069732e636f6d2f6f70656e7365612d7374617469632f6f70656e7365612d6a732d6c6f676f2d757064617465642e706e67" width="305" height="50" />

---
[![NuGet](https://img.shields.io/nuget/v/OpenSeaClient)](https://www.nuget.org/packages/OpenSeaClient/) 
[![GitHub](https://img.shields.io/github/license/ninjastacktech/opensea-net)](https://github.com/ninjastacktech/opensea-net/blob/master/LICENSE)

.NET 6 C# SDK for the OpenSea marketplace API.

The API docs can be found here: https://docs.opensea.io/reference/api-overview

Demo API swagger: https://ninja-opensea.azurewebsites.net/swagger/index.html

# install
```xml
PM> Install-Package OpenSeaClient -Version 1.0.7
```
# snippets

### DI configuration:
```C#
builder.Services.AddHttpClient<IOpenSeaClient, OpenSeaHttpClient>(config =>
{
    config.DefaultRequestHeaders.Add("X-Api-Key", "<your_api_key_here>");
});
```

### Get assets in batches of 50 with 1s delay between API calls to avoid throttling:
```C#
var client = new OpenSeaHttpClient(apiKey: "<your_api_key_here>");

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

    await Task.Delay(1000);
}
while (count == 50);
```

### Get the price of a token's sale order:
Note that the listing price of an asset is equal to the currentPrice of the lowest valid sell order on the asset. 
Users can lower their listing price without invalidating previous sell orders, so all get shipped down until they're canceled, or one is fulfilled.
```C#
var client = new OpenSeaHttpClient(apiKey: "<your_api_key_here>");

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
```


---

### MIT License



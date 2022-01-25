using Nethereum.Web3;
using OpenSeaClient;
using OpenSeaClient.DemoConsole;
using System.Numerics;

var client = new OpenSeaHttpClient(apiKey: "");

//var assets = await client.GetAssetsAsync(new GetAssetsQueryParams
//{
//    AssetContractAddress = "0x986aea67c7d6a15036e18678065eb663fc5be883",
//    OrderBy = OrderAssetsBy.ListingDate,
//});

//var orders = await client.GetOrdersAsync(new GetOrdersQueryParams
//{
//    AssetContractAddress = "0x986aea67c7d6a15036e18678065eb663fc5be883",
//    TokenId = "3832",
//    Side = 1,
//    SaleKind = 0,
//});

//var events = await client.GetEventsAsync(new GetEventsQueryParams
//{
//    AssetContractAddress = "0x986aea67c7d6a15036e18678065eb663fc5be883",
//    TokenId = "2314",
//});

//await Snippets.ImportCollectionAssetsAsync(apiKey: "", collectionSlug: "niftydegen");

//var tokenIds = await Snippets.SearchByTraitsAsync(
//    "metroverse",
//    //x => x.TraitType == "Buildings: Public" && x.Value == "Metroverse Museum",
//    //x => x.TraitType == "Buildings: Public" && x.Value == "Police Station",
//    x => x.TraitType == "Buildings: Industrial" && x.Value == "Wind Farm",
//    x => x.TraitType == "Buildings: Industrial" && x.Value == "Solar Farm"

//);


//var web3 = new Web3("https://mainnet.infura.io/v3/ddd5ed15e8d443e295b696c0d07c8b02");

//var abi = File.ReadAllText(@"C:\Users\User\Desktop\ntflabi.json");
//var contract = web3.Eth.GetContract(abi, "0x3c8d2fce49906e11e71cb16fa0ffeb2b16c29638");
//var function = contract.GetFunction("accumulated");

//var result = await function.CallAsync<BigInteger>(7358);
//var eth = Web3.Convert.FromWei(result);

 await Snippets.ComputePriceAsync(apiKey: "", collectionSlug: "niftydegen");

Console.ReadLine();

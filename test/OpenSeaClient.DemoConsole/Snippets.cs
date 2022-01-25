using Microsoft.EntityFrameworkCore;
using Nethereum.Web3;
using System.Linq.Expressions;
using System.Numerics;

namespace OpenSeaClient.DemoConsole
{
    public static class Snippets
    {
        public static async Task ImportCollectionAssetsAsync(string apiKey, string collectionSlug)
        {
            var client = new OpenSeaHttpClient(apiKey: apiKey);

            Console.WriteLine($"Querying for assets... pageSize = 50.");

            var assets = await client.GetAllAssetsAsync(new GetAssetsQueryParams
            {
                CollectionSlug = collectionSlug,
            });

            Console.WriteLine($"Done, got {assets.Count}.");

            Console.WriteLine($"Trying to save {assets.Count} assets in the database...");

            if (assets?.Any() == true)
            {
                using var dbContext = new AssetsDbContext();
                dbContext.Database.EnsureCreated();

                foreach (var asset in assets)
                {
                    if (asset.Traits != null)
                    {
                        foreach (var trait in asset.Traits)
                        {
                            dbContext.Assets.Add(new AssetDbModel
                            {
                                CollectionSlug = asset.Collection?.Slug,
                                ContractAddress = asset.AssetContract?.Address,
                                TokenId = asset.TokenId,
                                TraitType = trait.TraitType,
                                Value = trait.Value,
                                Name = asset.Name,
                                ImageUrl = asset.ImageUrl,
                                Url = $"https://opensea.io/assets/{asset.AssetContract?.Address}/{asset.TokenId}"
                            });
                        }
                    }
                }

                await dbContext.SaveChangesAsync();
            }

            Console.WriteLine($"Done.");
        }

        public static async Task ComputePriceAsync(string apiKey, string collectionSlug)
        {
            var client = new OpenSeaHttpClient(apiKey: apiKey);
            using var dbContext = new AssetsDbContext();
            dbContext.Database.EnsureCreated();

            var web3 = new Web3("https://mainnet.infura.io/v3/ddd5ed15e8d443e295b696c0d07c8b02");

            var abi = File.ReadAllText(@"C:\Users\User\Desktop\ntflabi.json");
            var contract = web3.Eth.GetContract(abi, "0x3c8d2fce49906e11e71cb16fa0ffeb2b16c29638");
            var function = contract.GetFunction("accumulated");

            var assets = await dbContext.Assets.Where(x => x.CollectionSlug == collectionSlug && x.IsProcessed == null).ToListAsync();

            foreach (var group in assets.Where(x => x.TokenId != null).GroupBy(x => x.TokenId).OrderBy(x => x.Key))
            {
                Console.WriteLine($"Processing token {group.Key}...");

                var firstAsset = group.FirstOrDefault();

                if (firstAsset != null)
                {
                    var orders = await client.GetOrdersAsync(new GetOrdersQueryParams
                    {
                        AssetContractAddress = firstAsset.ContractAddress,
                        TokenId = group.Key,
                        Side = 1,
                        SaleKind = 0,
                    });

                    if (orders?.Any() == true)
                    {
                        var order = orders.Where(x => x.Cancelled == false).OrderBy(x => x.CurrentPriceEth).FirstOrDefault();

                        if (order != null)
                        {
                            Console.WriteLine($"Found token {group.Key} with sell order {order.CurrentPriceEth} ETH");

                            var result = await function.CallAsync<BigInteger>(group.Key);
                            var ntfl = Web3.Convert.FromWei(result);

                            Console.WriteLine($"Token {group.Key} has {ntfl} NTFL tokens");

                            foreach (var item in group)
                            {
                                item.IsOnSale = true;
                                item.Price = (double?)order.CurrentPriceEth;
                                item.Accumulated = (double?)ntfl;
                            }
                        }
                    }

                    foreach (var item in group)
                    {
                        item.IsProcessed = true;
                    }

                    await dbContext.SaveChangesAsync();

                    await Task.Delay(6000);
                }
            }
        }

        public static async Task<IEnumerable<string?>> SearchByTraitsAsync(string collectionSlug, params Expression<Func<AssetDbModel, bool>>[] traitFilters)
        {
            using var dbContext = new AssetsDbContext();

            var query = dbContext.Assets.AsQueryable();

            var traitsCount = traitFilters.Length;

            if (traitsCount == 0)
            {
                throw new ArgumentException("traitFilters cannot be empty");
            }

            var traitFilter = traitFilters[0];

            foreach (var filter in traitFilters.Skip(1))
            {
                traitFilter = traitFilter.Or(filter);
            }

            var assets = await dbContext
                .Assets
                .Where(x => x.CollectionSlug == collectionSlug)
                .Where(traitFilter)
                .ToListAsync();

            return assets
                .GroupBy(x => x.TokenId)
                .Where(x => x.Count() == traitsCount)
                .Select(x => x.Key);
        }
    }
}

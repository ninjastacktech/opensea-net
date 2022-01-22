using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace OpenSeaClient.DemoConsole
{
    public static class Snippets
    {
        public static async Task ImportCollectionAssetsAsync(string apiKey, string collectionSlug)
        {
            var client = new OpenSeaHttpClient(apiKey: apiKey);

            using var dbContext = new AssetsDbContext();
            dbContext.Database.EnsureCreated();

            var count = 0;
            var limit = 50;
            var it = 0;

            do
            {
                var assets = await client.GetAssetsAsync(new GetAssetsQueryParams
                {
                    CollectionSlug = collectionSlug,
                    Offset = limit * it,
                    Limit = limit,
                });

                if (assets != null)
                {
                    count = assets.Count;

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
                                });
                            }
                        }
                    }
                    it++;

                    Console.WriteLine($"Get {assets.Count} assets [offset: {limit * it} limit: {limit}]");
                }
                else
                {
                    break;
                }

                await Task.Delay(1000);
            }
            while (count == 50);

            await dbContext.SaveChangesAsync();

            Console.WriteLine($"Done.");
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

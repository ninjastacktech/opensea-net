namespace OpenSeaClient
{
    public static class OpenSeaClientExtensions
    {
        /// <summary>
        /// Get assets in batches of 50 with a default 1s delay between API calls to avoid throttling.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="queryParams"></param>
        /// <param name="taskDelayMs"></param>
        /// <returns></returns>
        public static async Task<List<Asset>> GetAllAssetsAsync(
            this OpenSeaHttpClient client,
            GetAssetsQueryParams queryParams,
            int taskDelayMs = 1000)
        {
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

            return assetsList;
        }
    }
}

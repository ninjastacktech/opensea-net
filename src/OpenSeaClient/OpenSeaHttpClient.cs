using Newtonsoft.Json.Linq;

namespace OpenSeaClient
{
    public class OpenSeaHttpClient : IOpenSeaClient
    {
        public const string ApiKeyHeaderName = "X-Api-Key";

        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://api.opensea.io/api/v1/";
        private readonly string _wyvernUrl = "https://api.opensea.io/wyvern/v1/";
        private readonly string? _apiKey;

        public OpenSeaHttpClient(HttpClient? client = null, string? apiKey = null)
        {
            _client = client ?? new HttpClient();
            _apiKey = apiKey ?? "";
        }

        public async Task<List<Order>?> GetOrdersAsync(GetOrdersQueryParams? queryParams = null, CancellationToken ct = default)
        {
            var uriPart = $"orders";

            List<(string, string)>? param = null;

            if (queryParams != null)
            {
                param = queryParams.ToQueryParameters();
            }

            var response = await RequestAsync(_wyvernUrl, uriPart, HttpMethod.Get, queryParams: param, ct: ct);

            var jo = JObject.Parse(response);

            var list = new List<Order>();

            if (jo != null)
            {
                var ja = jo.SelectToken("orders")?.ToArray();

                if (ja != null)
                {
                    foreach (var ji in ja)
                    {
                        var item = ji.ToObject<Order>();

                        if (item != null)
                        {
                            if (item.CurrentPrice != null)
                            {
                                item.CurrentPriceEth = UnitConversion.Convert.FromWei(
                                    BigDecimal.Parse(item.CurrentPrice).Mantissa);
                            }

                            list.Add(item);
                        }
                    }
                }
            }

            return list;
        }

        public async Task<List<Event>?> GetEventsAsync(GetEventsQueryParams? queryParams = null, CancellationToken ct = default)
        {
            var uriPart = $"events";

            List<(string, string)>? param = null;

            if (queryParams != null)
            {
                param = queryParams.ToQueryParameters();
            }

            var response = await RequestAsync(_baseUrl, uriPart, HttpMethod.Get, queryParams: param, ct: ct);

            var jo = JObject.Parse(response);

            var list = new List<Event>();

            if (jo != null)
            {
                var ja = jo.SelectToken("asset_events")?.ToArray();

                if (ja != null)
                {
                    foreach (var ji in ja)
                    {
                        var item = ji.ToObject<Event>();

                        if (item != null)
                        {
                            if (item.TotalPrice != null)
                            {
                                item.TotalPriceEth = UnitConversion.Convert.FromWei(
                                    BigDecimal.Parse(item.TotalPrice).Mantissa);
                            }

                            list.Add(item);
                        }
                    }
                }
            }

            return list;
        }

        public async Task<List<Asset>?> GetAssetsAsync(GetAssetsQueryParams? queryParams = null, CancellationToken ct = default)
        {
            var uriPart = $"assets";

            List<(string, string)>? param = null;

            if (queryParams != null)
            {
                param = queryParams.ToQueryParameters();
            }

            var response = await RequestAsync(_baseUrl, uriPart, HttpMethod.Get, queryParams: param, ct: ct);

            var jo = JObject.Parse(response);

            var list = new List<Asset>();

            if (jo != null)
            {
                var ja = jo.SelectToken("assets")?.ToArray();

                if (ja != null)
                {
                    foreach (var ji in ja)
                    {
                        var item = ji.ToObject<Asset>();

                        if (item != null)
                        {
                            list.Add(item);
                        }
                    }
                }
            }

            return list;
        }

        public async Task<Asset?> GetAssetAsync(string assetContractAddress, string tokenId, string? ownerAddress = null, CancellationToken ct = default)
        {
            var uriPart = $"asset/{assetContractAddress}/{tokenId}";

            if (ownerAddress != null)
            {
                uriPart = $"{uriPart}/?account_address={ownerAddress}";
            }

            var response = await RequestAsync(_baseUrl, uriPart, HttpMethod.Get, ct: ct);

            var jo = JObject.Parse(response);

            return jo?.ToObject<Asset>();
        }

        public async Task<AssetContract?> GetAssetContractAsync(string assetContractAddress, CancellationToken ct = default)
        {
            var uriPart = $"asset_contract/{assetContractAddress}";

            var response = await RequestAsync(_baseUrl, uriPart, HttpMethod.Get, ct: ct);

            var jo = JObject.Parse(response);

            return jo?.ToObject<AssetContract>();
        }

        public async Task<List<Collection>?> GetCollectionsAsync(GetCollectionsQueryParams? queryParams = null, CancellationToken ct = default)
        {
            var uriPart = $"collections";

            List<(string, string)>? param = null;

            if (queryParams != null)
            {
                param = queryParams.ToQueryParameters();
            }

            var response = await RequestAsync(_baseUrl, uriPart, HttpMethod.Get, queryParams: param, ct: ct);

            var ja = JArray.Parse(response);

            var list = new List<Collection>();

            foreach (var jo in ja)
            {
                var item = jo.ToObject<Collection>();

                if (item != null)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public async Task<Collection?> GetCollectionAsync(string collectionSlug, CancellationToken ct = default)
        {
            var response = await RequestAsync(_baseUrl, $"collection/{collectionSlug}", HttpMethod.Get, ct: ct);

            var jo = JObject.Parse(response);
            var stats = jo?.SelectToken("collection");

            return stats?.ToObject<Collection>();
        }

        public async Task<CollectionStats?> GetCollectionStatsAsync(string collectionSlug, CancellationToken ct = default)
        {
            var response = await RequestAsync(_baseUrl, $"collection/{collectionSlug}/stats", HttpMethod.Get, ct: ct);

            var jo = JObject.Parse(response);
            var stats = jo?.SelectToken("stats");

            return stats?.ToObject<CollectionStats>();
        }

        protected async Task<string> RequestAsync(
            string baseUrl,
            string uriPart,
            HttpMethod method,
            HttpContent? content = null,
            IEnumerable<(string, string)>? queryParams = null,
            Dictionary<string, string>? headers = null,
            CancellationToken ct = default)
        {
            var uri = new Uri(QueryHelpers.AddQueryString($"{baseUrl}{uriPart}", queryParams));

            using var request = new HttpRequestMessage(method, uri);

            if (!_client.DefaultRequestHeaders.Contains(ApiKeyHeaderName))
            {
                request.Headers.Add(ApiKeyHeaderName, _apiKey);
            }

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            if (content != null)
            {
                request.Content = content;
            }

            using var response = await _client.SendAsync(request, ct);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync(ct);
        }
    }
}
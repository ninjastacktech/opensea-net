using Newtonsoft.Json.Linq;

namespace OpenSeaClient
{
    public class OpenSeaHttpClient : IOpenSeaClient
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly string? _apiKey;

        public OpenSeaHttpClient(string? apiKey = null, HttpClient? client = null, string baseUrl = "https://api.opensea.io/api/v1/")
        {
            _apiKey = apiKey;
            _baseUrl = baseUrl;
            _client = client ?? new HttpClient();
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

            var ja = JArray.Parse(response);

            var list = new List<Asset>();

            foreach (var jo in ja)
            {
                var item = jo.ToObject<Asset>();

                if (item != null)
                {
                    list.Add(item);
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
            using var request = BuildRequest(baseUrl, uriPart, method, content, queryParams, headers);
            using var response = await _client.SendAsync(request, ct);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync(ct);
        }

        private HttpRequestMessage BuildRequest(
            string baseUrl,
            string uriPart,
            HttpMethod method,
            HttpContent? content = null,
            IEnumerable<(string, string)>? queryParams = null,
            Dictionary<string, string>? headers = null)
        {
            var uri = new Uri(QueryHelpers.AddQueryString($"{baseUrl}{uriPart}", queryParams));

            var requestMessage = new HttpRequestMessage(method, uri);

            requestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_5) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36");
            requestMessage.Headers.Add("referrer", uri.AbsoluteUri);
            
            if (_apiKey != null)
            {
                requestMessage.Headers.Add("X-Api-Key", _apiKey);
            }

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    requestMessage.Headers.Add(header.Key, header.Value);
                }
            }

            if (content != null)
            {
                requestMessage.Content = content;
            }

            return requestMessage;
        }
    }
}
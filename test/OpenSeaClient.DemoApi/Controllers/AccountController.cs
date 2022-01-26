using Microsoft.AspNetCore.Mvc;

namespace OpenSeaClient.DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IOpenSeaClient _openSeaClient;

        public AccountController(
            IOpenSeaClient openSeaClient,
            ILogger<AccountController> logger)
        {
            _openSeaClient = openSeaClient;
            _logger = logger;
        }

        [HttpGet("~/collections/{owner}")]
        public Task<List<Collection>?> GetCollections(string owner)
        {
            return _openSeaClient.GetCollectionsAsync(new GetCollectionsQueryParams
            {
                AssetOwner = owner,
                Limit = 50,
                Offset = 0,
            });
        }

        [HttpGet("~/assets/{collectionSlug}/{owner}")]
        public Task<List<Asset>?> GetAssets(string collectionSlug, string owner)
        {
            return _openSeaClient.GetAssetsAsync(new GetAssetsQueryParams
            {
                CollectionSlug = collectionSlug,
                OwnerAddress = owner,
                Limit = 50,
                Offset = 0,
            });
        }
    }
}
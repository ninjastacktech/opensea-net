using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class Account
    {
        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("profile_image_url")]
        public string? ProfileImageUrl { get; set; }
    }
}

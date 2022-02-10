using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class User
    {
        [JsonProperty("username")]
        public string? Username { get; set; }
    }
}

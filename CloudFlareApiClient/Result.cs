using Newtonsoft.Json;

namespace CloudFlareApiClient
{
    public abstract class Result
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace CloudFlareApiClient
{
    public abstract class Result
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudFlareApiClient
{
    public class BaseResponse<T>
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("errors")]
        public List<Dictionary<string, string>> Errors { get; set; }

        [JsonPropertyName("messages")]
        public List<Dictionary<string, string>> Messages { get; set; }

        [JsonPropertyName("result")]
        public List<T> Result { get; set; }
    }
}

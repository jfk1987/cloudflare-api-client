using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlareApiClient
{
    public class BaseResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        [JsonProperty("messages")]
        public List<Dictionary<string, string>> Messages { get; set; }
    }

    public partial class Error
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

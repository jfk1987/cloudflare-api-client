using System;
using Newtonsoft.Json;

namespace CloudFlareApiClient
{
    public class DnsRecordResult : Result
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("proxiable")]
        public bool Proxiable { get; set; }

        [JsonProperty("proxied")]
        public bool Proxied { get; set; }

        [JsonProperty("ttl")]
        public long Ttl { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("zone_id")]
        public string ZoneId { get; set; }

        [JsonProperty("zone_name")]
        public string ZoneName { get; set; }

        [JsonProperty("created_on")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("modified_on")]
        public DateTimeOffset ModifiedOn { get; set; }

        [JsonProperty("data")]
        public Object Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("auto_added")]
        public bool AutoAdded { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}

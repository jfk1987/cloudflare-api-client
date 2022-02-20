using System;
using System.Text.Json.Serialization;

namespace CloudFlareApiClient
{
    public class DnsRecordResult : Result
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("proxiable")]
        public bool Proxiable { get; set; }

        [JsonPropertyName("proxied")]
        public bool Proxied { get; set; }

        [JsonPropertyName("ttl")]
        public long Ttl { get; set; }

        [JsonPropertyName("locked")]
        public bool Locked { get; set; }

        [JsonPropertyName("zone_id")]
        public string ZoneId { get; set; }

        [JsonPropertyName("zone_name")]
        public string ZoneName { get; set; }

        [JsonPropertyName("created_on")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonPropertyName("modified_on")]
        public DateTimeOffset ModifiedOn { get; set; }

        [JsonPropertyName("data")]
        public Object Data { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }

    public partial class Meta
    {
        [JsonPropertyName("auto_added")]
        public bool AutoAdded { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }
    }
}

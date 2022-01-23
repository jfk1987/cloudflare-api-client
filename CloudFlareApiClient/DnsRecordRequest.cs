using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CloudFlareApiClient
{
    public class DnsRecordRequest
    {
        [JsonPropertyName("proxied")]
        public bool Proxied { get; set; } = true;

        [JsonPropertyName("type")]
        public DnsRecordType RecordType { get; set; } = DnsRecordType.A;

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

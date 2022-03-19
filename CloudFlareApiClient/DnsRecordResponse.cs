using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFlareApiClient
{
    public class DnsRecordResponse : BaseResponse
    {
        [JsonProperty("result")]
        [JsonConverter(typeof(SingleOrArrayZoneResultConverter<DnsRecordResult>))]
        public List<DnsRecordResult> Result { get; set; }
    }
}

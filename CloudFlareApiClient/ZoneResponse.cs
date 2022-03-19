using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFlareApiClient
{
    public class ZoneResponse : BaseResponse
    {
        [JsonProperty("result")]
        [JsonConverter(typeof(SingleOrArrayZoneResultConverter<ZoneResult>))]
        public List<ZoneResult> Result { get; set; }
    }
}

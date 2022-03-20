using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFlareApiClient
{
    public partial class Client
    {        
        public async Task<ZoneResponse> ListZonesAsync(List<UrlParameter> urlParameters)
        {
            var request = new RestRequest
            {
                Path = "/zones",
                UrlParameters = urlParameters
            };

            var response = await _client.GetRequestAsync(request);

            return DeserializeResponse<ZoneResponse>(response.Body);
        }
    }
}

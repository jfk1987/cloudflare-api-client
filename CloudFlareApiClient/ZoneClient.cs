using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFlareApiClient
{
    public partial class Client
    {
        /// <summary>
        /// Method to list all dns zones of an account
        /// </summary>
        /// <param name="urlParameters">(Optional) URL parameters</param>
        /// <returns>A ZoneResponse object</returns>
        public async Task<ZoneResponse> ListZonesAsync(List<UrlParameter> urlParameters = null)
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

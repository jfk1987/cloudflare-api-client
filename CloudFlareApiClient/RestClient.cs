using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFlareApiClient
{
    public class RestClient
    {
        private readonly Configuration _configuration;

        public RestClient(Configuration configuration)
        {
            _configuration = configuration;
        }

        public async Task<RestResponse> GetRequest(RestRequest request)
        {
            return null;
        }

        public async Task<RestResponse> PostRequest(RestRequest request)
        {
            return null;
        }

        public async Task<RestResponse> DeleteRequest(RestRequest request)
        {
            return null;
        }

        public async Task<RestResponse> PutRequest(RestRequest request)
        {
            return null;
        }

        public async Task<RestResponse> PatchRequest(RestRequest request)
        {
            return null;
        }
    }
}

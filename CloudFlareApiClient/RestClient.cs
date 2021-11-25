using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlareApiClient
{
    public abstract class RestClient
    {
        private readonly Configuration _configuration;

        private RestClient() { }

        public RestClient(Configuration configuration)
        {
            _configuration = configuration;
        }

        public abstract RestResponse GetRequest(RestRequest request);
        public abstract RestResponse PostRequest(RestRequest request);
        public abstract RestResponse DeleteRequest(RestRequest request);
        public abstract RestResponse PutRequest(RestRequest request);
        public abstract RestResponse PatchRequest(RestRequest request);
    }
}

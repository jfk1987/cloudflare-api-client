using System.Collections.Generic;

namespace CloudFlareApiClient
{
    public class RestRequest
    {
        public string Path { get; set; }
        public List<UrlParameter> UrlParameters { get; set; }
        public string Body { get; set; }

        public RestRequest()
        {
            UrlParameters = new List<UrlParameter>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlareApiClient
{
    public class RestRequest
    {
        public string Path { get; set; }
        public List<UrlParameter> UrlParameters { get; set; }
        public string Body { get; set; }
    }
}

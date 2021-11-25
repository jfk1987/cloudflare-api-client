using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlareApiClient
{
    public class RestRequest
    {
        public string path;
        public List<Dictionary<string, string>> UrlParameters { get; set; }
        public string Body { get; set; }
    }
}

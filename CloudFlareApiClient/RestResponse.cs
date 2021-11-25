using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlareApiClient
{
    public class RestResponse
    {
        public bool Successful { get; set; }
        public string Body { get; set; }
        public List<string> Header { get; set; }
        public string ReturnCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlareApiClient
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public List<Dictionary<string, string>> Errors { get; set; }
        public List<Dictionary<string, string>> Messages { get; set; }
        public List<Result> Result { get; set; }
    }
}

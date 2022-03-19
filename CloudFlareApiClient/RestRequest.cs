using System.Collections.Generic;

namespace CloudFlareApiClient
{
    public class RestRequest
    {
        private List<UrlParameter> _urlParameters = new List<UrlParameter>();

        public string Path { get; set; }
        public List<UrlParameter> UrlParameters 
        { 
            get => _urlParameters; 
            set => SetUrlParameters(value); 
        }
        public string Body { get; set; }

        public RestRequest()
        {
            UrlParameters = new List<UrlParameter>();
        }

        public void SetUrlParameters(List<UrlParameter> parameters)
        {
            if(parameters != null)
            {
                _urlParameters = parameters;
            }
        }
    }
}

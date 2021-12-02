using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CloudFlareApiClient
{
    public class RestClient
    {
        internal enum RequestType 
        {
            GET,
            POST,
            PUT,
            DELETE,
            PATCH
        }

        private readonly HttpClient _client;
        private readonly Configuration _configuration;

        private const string BASEURL = "https://api.cloudflare.com/client/v4";

        public RestClient(Configuration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration.ApiToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<RestResponse> GetRequestAsync(RestRequest request)
        {
            return await SendRequest(RequestType.GET, request);
        }

        public async Task<RestResponse> PostRequestAsync(RestRequest request)
        {
            return await SendRequest(RequestType.POST, request);
        }

        public async Task<RestResponse> DeleteRequestAsync(RestRequest request)
        {
            return await SendRequest(RequestType.DELETE, request);
        }

        public async Task<RestResponse> PutRequestAsync(RestRequest request)
        {
            return await SendRequest(RequestType.PUT, request);
        }

        public async Task<RestResponse> PatchRequestAsync(RestRequest request)
        {
            return await SendRequest(RequestType.PATCH, request);
        }

        private async Task<RestResponse> SendRequest(RequestType requestType, RestRequest request)
        {
            var uri = BuildRequestUrl(request.Path, request.UrlParameters);

            HttpResponseMessage response;

            switch (requestType)
            {
                case RequestType.GET: response = await _client.GetAsync(uri); break;
                case RequestType.PUT: response = await _client.PutAsync(uri, new StringContent(request.Body)); break;
                case RequestType.POST: response = await _client.PostAsync(uri, new StringContent(request.Body)); break;
                case RequestType.PATCH: response = await _client.PatchAsync(uri, new StringContent(request.Body)); break;
                case RequestType.DELETE: response = await _client.DeleteAsync(uri); break;
                default: throw new NotImplementedException();                
            }

            return await ProcessResponseAsync(response);
        }

        private string BuildRequestUrl(string path, List<UrlParameter> urlParameters)
        {
            string connector = "?";
            string uri = BASEURL + path;

            if(urlParameters.Count == 0)
            {
                return uri;
            }

            foreach(var urlParameter in urlParameters)
            {
                uri += connector + $"{urlParameter.ParameterName}={urlParameter.Value}";
                connector = "&";
            }

            return uri;
        }

        private async Task<RestResponse> ProcessResponseAsync(HttpResponseMessage httpResponse)
        {
            RestResponse response = new RestResponse();

            response.Successful = httpResponse.IsSuccessStatusCode;
            response.ReturnCode = httpResponse.StatusCode.ToString();
            response.Body = await httpResponse.Content.ReadAsStringAsync();

            var result = from hr in httpResponse.Headers
                         select new Dictionary<string, string>() { { "parameter", hr.Key }, { "value", hr.Value.First() } };

            response.Header = result.ToList();

            return response;
        }
    }
}

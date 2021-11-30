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

        public async Task<RestResponse> GetRequest(RestRequest request)
        {
            var uri = BuildRequestUrl(request.Path, request.UrlParameters);

            var response = await _client.GetAsync(uri);
            
            return await ProcessResponse(response);
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

        private async Task<RestResponse> ProcessResponse(HttpResponseMessage httpResponse)
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

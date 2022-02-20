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

        /// <summary>
        /// Create an instance of RestClient class
        /// </summary>
        /// <param name="configuration">Configuration object</param>
        public RestClient(Configuration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration.ApiToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region REST functions

        /// <summary>
        /// Function to send a GET request
        /// </summary>
        /// <param name="request">RestRequest object</param>
        /// <returns>RestResponse object</returns>
        public async Task<RestResponse> GetRequestAsync(RestRequest request)
        {
            return await SendRequest(RequestType.GET, request);
        }

        /// <summary>
        /// Function to send a POST request
        /// </summary>
        /// <param name="request">RestRequest object</param>
        /// <returns>RestResponse object</returns>
        public async Task<RestResponse> PostRequestAsync(RestRequest request)
        {
            return await SendRequest(RequestType.POST, request);
        }

        /// <summary>
        /// Function to send a DELETE request
        /// </summary>
        /// <param name="request">RestRequest object</param>
        /// <returns>RestResponse object</returns>
        public async Task<RestResponse> DeleteRequestAsync(RestRequest request)
        {
            return await SendRequest(RequestType.DELETE, request);
        }

        /// <summary>
        /// Function to send a PUT request
        /// </summary>
        /// <param name="request">RestRequest object</param>
        /// <returns>RestResponse object</returns>
        public async Task<RestResponse> PutRequestAsync(RestRequest request)
        {
            return await SendRequest(RequestType.PUT, request);
        }

        /// <summary>
        /// Function to send a PATCH request
        /// </summary>
        /// <param name="request">RestRequest object</param>
        /// <returns>RestResponse object</returns>
        public async Task<RestResponse> PatchRequestAsync(RestRequest request)
        {
            return await SendRequest(RequestType.PATCH, request);
        }

        #endregion

        #region Helper functions

        /// <summary>
        /// Function to send a http request 
        /// </summary>
        /// <param name="requestType">Type of the request</param>
        /// <param name="request">Actual request object</param>
        /// <returns>A RestResponse object</returns>
        /// <exception cref="NotImplementedException">Thrown if an unsupported method code is given</exception>
        private async Task<RestResponse> SendRequest(RequestType requestType, RestRequest request)
        {
            var uri = BuildRequestUrl(request.Path, request.UrlParameters);

            HttpResponseMessage response = requestType switch
            {
                RequestType.GET => await _client.GetAsync(uri),
                RequestType.PUT => await _client.PutAsync(uri, new StringContent(request.Body)),
                RequestType.POST => await _client.PostAsync(uri, new StringContent(request.Body)),
                RequestType.PATCH => await _client.PatchAsync(uri, new StringContent(request.Body)),
                RequestType.DELETE => await _client.DeleteAsync(uri),
                _ => throw new NotImplementedException(),
            };

            return await ProcessResponseAsync(response);
        }

        /// <summary>
        /// Function to create the request url
        /// </summary>
        /// <param name="path">The relative path to the resource</param>
        /// <param name="urlParameters">List of UrlParameter objects for all url parameters</param>
        /// <returns>String with the whole absolute url</returns>
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

        /// <summary>
        /// Helper function to process the plain http response to a RestResponse object
        /// </summary>
        /// <param name="httpResponse">A HttpResonseMessage object</param>
        /// <returns>A RestResponse object filled with data from the http response</returns>
        private async Task<RestResponse> ProcessResponseAsync(HttpResponseMessage httpResponse)
        {
            RestResponse response = new RestResponse
            {
                Successful = httpResponse.IsSuccessStatusCode,
                ReturnCode = httpResponse.StatusCode.ToString(),
                Body = await httpResponse.Content.ReadAsStringAsync()
            };

            var result = from hr in httpResponse.Headers
                         select new Dictionary<string, string>() { { "parameter", hr.Key }, { "value", hr.Value.First() } };

            response.Header = result.ToList();

            return response;
        }

        #endregion
    }
}

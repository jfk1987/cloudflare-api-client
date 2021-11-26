using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CloudFlareApiClient
{
    public class Client
    {
        private readonly RestClient _client;
        private readonly Configuration _configuration;
        private const string BASEURL = "https://api.cloudflare.com/client/v4";

        public Client(Configuration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(configuration);
        }

        public Client(Configuration configuration, RestClient restClient)
        {
            _client = restClient;
        }
        public Configuration GetConfiguration()
        {
            return _configuration;
        }

        public async void UpdateDnsRecord()
        {
            

            DnsRecordRequest request = new DnsRecordRequest
            {
                Content = "",
                Name = "",
                RecordType = DnsRecordType.A,
                Proxied = true,
            };

            SendRequest(HttpMethod.PATCH, $"/zones/{_configuration.ZoneId}/dns_records");               
        }

        public async Task<string> GetRecords()
        {
            var response = await SendRequest(HttpMethod.GET, $"/zones/{_configuration.ZoneId}/dns_records");

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> SendRequest(HttpMethod method, string path, string content = null)
        {
            HttpClient client = new HttpClient();

            string requestPath = BASEURL + path;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration.ApiToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;       
            
            switch(method)
            {
                case HttpMethod.GET: response = await client.GetAsync(requestPath); break;
                case HttpMethod.POST: response = await client.PostAsync(requestPath, null); break;
                case HttpMethod.PATCH: response = await client.PatchAsync(requestPath, null); break;
                case HttpMethod.PUT: response = await client.PutAsync(requestPath, null); break;
                case HttpMethod.DELETE: response = await client.DeleteAsync(requestPath); break;
                default: throw new ArgumentException("Unimplemented HTTP method!");
            }

            return response;
        }
    }
}

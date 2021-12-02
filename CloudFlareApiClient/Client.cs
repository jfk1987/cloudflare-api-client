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

        public Client(Configuration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(configuration);
        }

        public Configuration GetConfiguration()
        {
            return _configuration;
        }

        public async Task GetDnsZonesAsync()
        {
            var request = new RestRequest
            {
                Path = "/zones"
            };

            var response = await _client.GetRequestAsync(request);
        }

        //public async void UpdateDnsRecord()
        //{
            

        //    DnsRecordRequest request = new DnsRecordRequest
        //    {
        //        Content = "",
        //        Name = "",
        //        RecordType = DnsRecordType.A,
        //        Proxied = true,
        //    };

        //    SendRequest(HttpMethod.PATCH, $"/zones/{_configuration.ZoneId}/dns_records");               
        //}

        //public async Task<string> GetRecords()
        //{
        //    var response = await SendRequest(HttpMethod.GET, $"/zones/{_configuration.ZoneId}/dns_records");

        //    return await response.Content.ReadAsStringAsync();
        //}
    }
}

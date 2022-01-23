using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;

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

        public async Task GetDnsZonesAsync(List<UrlParameter> urlParameters)
        {
            var request = new RestRequest
            {
                Path = "/zones",
                UrlParameters = urlParameters
            };

            var response = await _client.GetRequestAsync(request);
        }

        public async Task GetZoneRecords(string zoneId, List<UrlParameter> urlParameters)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records",
                UrlParameters = urlParameters
            };

            var response = await _client.GetRequestAsync(request);
        }

        public async Task PostZoneRecord(string zoneId, List<UrlParameter> urlParameters, DnsRecordRequest dnsRecordRequest)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records",
                UrlParameters = urlParameters,
                Body = SerializeRequest<DnsRecordRequest>(dnsRecordRequest)
            };

            var response = await _client.PostRequestAsync(request);
        }

        public async Task PutZoneRecord(string zoneId, List<UrlParameter> urlParameters, DnsRecordRequest dnsRecordRequest)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records",
                UrlParameters = urlParameters,
                Body = SerializeRequest<DnsRecordRequest>(dnsRecordRequest)
            };

            var response = await _client.PostRequestAsync(request);
        }

        private string SerializeRequest<T>(T requestObject)
        {
            return JsonSerializer.Serialize(requestObject);
        }
    }
}

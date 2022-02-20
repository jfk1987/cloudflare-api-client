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

        public async Task<ZoneResponse> ListZonesAsync(List<UrlParameter> urlParameters)
        {
            var request = new RestRequest
            {
                Path = "/zones",
                UrlParameters = urlParameters
            };

            var response = await _client.GetRequestAsync(request);

            return DeserializeResponse<ZoneResponse>(response.Body);
        }

        public async Task<DnsRecordResponse> ListDnsRecords(string zoneId, List<UrlParameter> urlParameters)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records",
                UrlParameters = urlParameters
            };

            var response = await _client.GetRequestAsync(request);

            return DeserializeResponse<DnsRecordResponse>(response.Body);
        }

        public async Task<DnsRecordResponse> CreateDnsRecord(string zoneId, List<UrlParameter> urlParameters, DnsRecordRequest dnsRecordRequest)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records",
                UrlParameters = urlParameters,
                Body = SerializeRequest(dnsRecordRequest)
            };

            var response = await _client.PostRequestAsync(request);

            return DeserializeResponse<DnsRecordResponse>(response.Body);
        }

        public async Task<DnsRecordResponse> UpdateDnsRecord(string zoneId, List<UrlParameter> urlParameters, DnsRecordRequest dnsRecordRequest)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records",
                UrlParameters = urlParameters,
                Body = SerializeRequest<DnsRecordRequest>(dnsRecordRequest)
            };

            var response = await _client.PostRequestAsync(request);

            return DeserializeResponse<DnsRecordResponse>(response.Body);
        }

        private string SerializeRequest<T>(T requestObject)
        {
            return JsonSerializer.Serialize(requestObject);
        }

        private T DeserializeResponse<T>(string response)
        {
            return JsonSerializer.Deserialize<T>(response);
        }
    }
}

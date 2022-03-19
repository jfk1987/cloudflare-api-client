using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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

        public async Task<DnsRecordResponse> ListDnsRecordsAsync(List<UrlParameter> urlParameters)
        {
            return await ListDnsRecordsAsync(_configuration.ZoneId, urlParameters);
        }

        public async Task<DnsRecordResponse> ListDnsRecordsAsync(string zoneId, List<UrlParameter> urlParameters)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records",
                UrlParameters = urlParameters
            };

            var response = await _client.GetRequestAsync(request);

            return DeserializeResponse<DnsRecordResponse>(response.Body);
        }

        public async Task<DnsRecordResponse> CreateDnsRecordAsync(List<UrlParameter> urlParameters, DnsRecordRequest dnsRecordRequest)
        {
            return await CreateDnsRecordAsync(_configuration.ZoneId, urlParameters, dnsRecordRequest);
        }

        public async Task<DnsRecordResponse> CreateDnsRecordAsync(string zoneId, List<UrlParameter> urlParameters, DnsRecordRequest dnsRecordRequest)
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

        public async Task<DnsRecordResponse> UpdateDnsRecordAsync(List<UrlParameter> urlParameters, DnsRecordRequest dnsRecordRequest)
        {
            return await UpdateDnsRecordAsync(_configuration.ZoneId, urlParameters, dnsRecordRequest);
        }

        public async Task<DnsRecordResponse> UpdateDnsRecordAsync(string zoneId, List<UrlParameter> urlParameters, DnsRecordRequest dnsRecordRequest)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records",
                UrlParameters = urlParameters,
                Body = SerializeRequest<DnsRecordRequest>(dnsRecordRequest)
            };

            var response = await _client.PutRequestAsync(request);

            return DeserializeResponse<DnsRecordResponse>(response.Body);
        }

        private string SerializeRequest<T>(T requestObject)
        {
            var options = new JsonSerializerSettings
            {
                Converters =
                {
                    new StringEnumConverter()
                }
            };

            return JsonConvert.SerializeObject(requestObject, options);
        }

        private T DeserializeResponse<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}

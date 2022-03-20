using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudFlareApiClient
{
    /// <summary>
    /// Partial Client class including all dns record specific requests
    /// </summary>
    public partial class Client
    {
        /// <summary>
        /// Method to list all dns records of the zone (using zone id from configuration)
        /// </summary>
        /// <param name="urlParameters">(Optional) URL parameters to limit the results</param>
        /// <returns>DNS record response object</returns>
        public async Task<DnsRecordResponse> ListDnsRecordsAsync(List<UrlParameter> urlParameters = null)
        {
            return await ListDnsRecordsAsync(_configuration.ZoneId, urlParameters);
        }

        /// <summary>
        /// Method to list all dns records of the zone
        /// </summary>
        /// <param name="zoneId">ID of the zone where the record exists</param>
        /// <param name="urlParameters">(Optional) URL parameters to limit the results</param>
        /// <returns>DNS record response object</returns>
        public async Task<DnsRecordResponse> ListDnsRecordsAsync(string zoneId, List<UrlParameter> urlParameters = null)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records",
                UrlParameters = urlParameters
            };

            var response = await _client.GetRequestAsync(request);

            return DeserializeResponse<DnsRecordResponse>(response.Body);
        }

        /// <summary>
        /// Method to create a new dns record (using zone id from configuration)
        /// </summary>
        /// <param name="dnsRecordRequest">Request body</param>
        /// <param name="urlParameters">(Optional) URL parameters</param>
        /// <returns>DNS record response object</returns>
        public async Task<DnsRecordResponse> CreateDnsRecordAsync(DnsRecordRequest dnsRecordRequest, List<UrlParameter> urlParameters = null)
        {
            return await CreateDnsRecordAsync(_configuration.ZoneId, dnsRecordRequest, urlParameters);
        }

        /// <summary>
        /// Method to create a new dns record
        /// </summary>
        /// <param name="zoneId">ID of the zone where the record exists</param>
        /// <param name="dnsRecordRequest">Request body</param>
        /// <param name="urlParameters">(Optional) URL parameters</param>
        /// <returns>DNS record response object</returns>
        public async Task<DnsRecordResponse> CreateDnsRecordAsync(string zoneId, DnsRecordRequest dnsRecordRequest, List<UrlParameter> urlParameters = null)
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

        /// <summary>
        /// Method to update an existing DNS record (using zone id from configuration)
        /// </summary>
        /// <param name="dnsRecordId">ID of the DNS record to update</param>
        /// <param name="dnsRecordRequest">Request body</param>
        /// <param name="urlParameters">(Optional) URL parameters</param>
        /// <returns>DNS record response object</returns>
        public async Task<DnsRecordResponse> UpdateDnsRecordAsync(string dnsRecordId, DnsRecordRequest dnsRecordRequest, List<UrlParameter> urlParameters = null)
        {
            return await UpdateDnsRecordAsync(_configuration.ZoneId, dnsRecordId, dnsRecordRequest, urlParameters);
        }

        /// <summary>
        /// Method to update an existing DNS record
        /// </summary>
        /// <param name="zoneId">ID of the zone where the record exists</param>
        /// <param name="dnsRecordId">ID of the DNS record to update</param>
        /// <param name="dnsRecordRequest">Request body</param>
        /// <param name="urlParameters">(Optional) URL parameters</param>
        /// <returns>DNS record response object</returns>
        public async Task<DnsRecordResponse> UpdateDnsRecordAsync(string zoneId, string dnsRecordId, DnsRecordRequest dnsRecordRequest, List<UrlParameter> urlParameters = null)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records/{dnsRecordId}",
                UrlParameters = urlParameters,
                Body = SerializeRequest(dnsRecordRequest)
            };

            var response = await _client.PutRequestAsync(request);

            return DeserializeResponse<DnsRecordResponse>(response.Body);
        }

        /// <summary>
        /// Method to delete an existing DNS record
        /// </summary>
        /// <param name="dnsRecordId">ID of the DNS record to update</param>
        /// <param name="urlParameters">(Optional) URL parameters</param>
        /// <returns>DNS record response object</returns>
        public async Task<DnsRecordResponse> DeleteDnsRecordAsync(string dnsRecordId, List<UrlParameter> urlParameters = null)
        {
            return await DeleteDnsRecordAsync(_configuration.ZoneId, dnsRecordId, urlParameters);
        }

        /// <summary>
        /// Method to delete an existing DNS record
        /// </summary>
        /// <param name="zoneId">ID of the zone where the record exists</param>
        /// <param name="dnsRecordId">ID of the DNS record to update</param>
        /// <param name="urlParameters">(Optional) URL parameters</param>
        /// <returns>DNS record response object</returns>
        public async Task<DnsRecordResponse> DeleteDnsRecordAsync(string zoneId, string dnsRecordId, List<UrlParameter> urlParameters = null)
        {
            var request = new RestRequest
            {
                Path = $"/zones/{zoneId}/dns_records/{dnsRecordId}",
                UrlParameters = urlParameters
            };

            var response = await _client.PutRequestAsync(request);

            return DeserializeResponse<DnsRecordResponse>(response.Body);
        }
    }
}

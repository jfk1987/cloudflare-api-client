using System;

namespace CloudFlareApiClient
{
    public class Configuration
    {
        public string ApiKey { get; }
        public string AuthEmail { get; }
        public string ApiToken { get; }
        public string ZoneId { get; }

        public Configuration(string apiKey, string authMail, string zoneId)
        {
            ApiKey = apiKey;
            AuthEmail = authMail;
            ZoneId = zoneId;
        }

        public Configuration(string apiToken, string zoneId)
        {
            ApiToken = apiToken;
            ZoneId = zoneId;
        }
    }
}

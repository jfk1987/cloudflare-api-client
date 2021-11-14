using CloudFlareApiClient;
using Xunit;

namespace CloudFlareApiClientTest
{
    public class ConfigurationTest
    {
        [Fact]
        public void ConstructorTest()
        {
            string apiKey = "thisIsAnApiKey";
            string authMail = "test@test.com";
            string zone01 = "aaaa33333bbbb4444";
            
            Configuration config01 = new Configuration(apiKey, authMail, zone01);

            Assert.Equal(apiKey, config01.ApiKey);
            Assert.Equal(authMail, config01.AuthEmail);
            Assert.Equal(zone01, config01.ZoneId);

            string apiToken = "thisIsAnApiToken";
            string zone02 = "ddddd6666eeee7777";
            Configuration config02 = new Configuration(apiToken, zone02);

            Assert.Equal(apiToken, config02.ApiToken);
            Assert.Equal(zone02, config02.ZoneId);
        }

    }
}

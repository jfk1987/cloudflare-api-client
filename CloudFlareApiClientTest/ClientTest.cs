using CloudFlareApiClient;
using Xunit;

namespace CloudFlareApiClientTest
{
    public class ClientTest
    {
        [Fact]
        public void ContructorTest()
        {
            Configuration config01 = new Configuration("", "", "");
            Client client01 = new Client(config01);

            Assert.Equal(config01, client01.GetConfiguration());

            Configuration config02 = new Configuration("", "");
            Client client02 = new Client(config02);

            Assert.Equal(config02, client02.GetConfiguration());

            Assert.NotEqual(client01.GetConfiguration(), client02.GetConfiguration());
        }
    }
}

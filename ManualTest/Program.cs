using CloudFlareApiClient;
using System;
using System.Threading.Tasks;

namespace ManualTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string apiToken = "";
            string zoneId = "";

            Configuration configuration = new Configuration(apiToken, zoneId);
            Client client = new Client(configuration);

            var test = await client.GetRecords();

            Console.WriteLine(test);
        }
    }
}

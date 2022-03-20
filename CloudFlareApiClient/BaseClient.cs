using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlareApiClient
{
    public partial class Client
    {
        private readonly RestClient _client;
        private readonly Configuration _configuration;

        public Client(Configuration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(configuration);
        }

        /// <summary>
        /// Get method for the configuration
        /// </summary>
        /// <returns>Configuration object</returns>
        public Configuration GetConfiguration()
        {
            return _configuration;
        }
             
        /// <summary>
        /// Helper method to serialize request objects to JSON string
        /// </summary>
        /// <typeparam name="T">Generic for the type of the object to serialize</typeparam>
        /// <param name="requestObject">Object to serialize</param>
        /// <returns>Serialized string</returns>
        private static string SerializeRequest<T>(T requestObject)
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

        /// <summary>
        /// Helper method to deserialize response JSON string to an object
        /// </summary>
        /// <typeparam name="T">Generic for the type of the object to deserialize</typeparam>
        /// <param name="response">JSON string to </param>
        /// <returns></returns>
        private static T DeserializeResponse<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}

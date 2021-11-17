using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlareApiClient
{
    public class Client
    {
        private Configuration _configuration;

        public Client(Configuration configuration)
        {
            _configuration = configuration;
        }

        public Configuration GetConfiguration()
        {
            return _configuration;
        }
    }
}

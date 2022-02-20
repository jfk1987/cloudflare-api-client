using System;
using System.Text.Json.Serialization;

namespace CloudFlareApiClient
{
    public class DnsRecordRequest
    {
        private bool _proxied = true;
        private DnsRecordType _recordType = DnsRecordType.A;
        private string _content;
        private string _name;
        private int _ttl = 1;

        [JsonPropertyName("proxied")]        
        public bool Proxied 
        { 
            get => _proxied; 
            set => _proxied = value; 
        }

        [JsonPropertyName("type")]
        public DnsRecordType RecordType
        { 
            get => _recordType; 
            set => _recordType = value; 
        }

        [JsonPropertyName("content")]
        public string Content 
        { 
            get => _content; 
            set => _content = value; 
        }

        [JsonPropertyName("name")]
        public string Name 
        { 
            get => _name; 
            set => SetName(value); 
        }

        [JsonPropertyName("ttl")]
        public int TTL 
        { 
            get => _ttl; 
            set => SetTTL(value); 
        }

        public DnsRecordRequest(string content, string name)
        {
            Content = content;
            Name = name;
        }

        public DnsRecordRequest(string content, string name, DnsRecordType recordType) : this(content, name)
        {
            RecordType = recordType;
        }

        public DnsRecordRequest(string content, string name, int ttl) : this(content, name)
        {
            TTL = ttl;
        }

        public DnsRecordRequest(string content, string name, bool proxied) : this(content, name)
        {
            Proxied = proxied;
        }

        public DnsRecordRequest(string content, string name, DnsRecordType recordType, int ttl) : this(content, name, recordType)
        {
            TTL = ttl;
        }

        public DnsRecordRequest(string content, string name, DnsRecordType recordType, bool proxied) : this(content, name, recordType)
        {
            Proxied = proxied;
        }

        public DnsRecordRequest(string content, string name, int ttl, bool proxied) : this(content, name, proxied)
        {
            TTL = ttl;
        }

        public DnsRecordRequest(string content, string name, DnsRecordType recordType, int ttl, bool proxied) : this(content, name, recordType, proxied)
        {
            TTL = ttl;
        }

        public void SetTTL(int ttl)
        {
            if (ttl != 1 && ttl < 60 || ttl > 86400)
            {
                //TODO: create own exception
                throw new ArgumentOutOfRangeException("Value should be 1 or between 60 and 86400!");
            }

            _ttl = ttl;
        }

        public void SetName(string name)
        {
            if(name == null || name.Length > 255)
            {
                throw new ArgumentException("Value should not be null or longer than 255!");
            }

            _name = name;
        }
    }
}

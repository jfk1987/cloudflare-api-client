using CloudFlareApiClient;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CloudFlareApiClientTest
{
    public class DnsRecordRequestTest
    {
        [Fact]
        public void ConstructorTest()
        {
            string name = "sub.test.com";
            string content = "172.0.0.1";
            DnsRecordType recordType = DnsRecordType.AAAA;
            int ttl = 60;
            bool proxied = false;

            DnsRecordRequest request01 = new DnsRecordRequest(content, name);
            Assert.Equal(name, request01.Name);
            Assert.Equal(content, request01.Content);
            Assert.Equal(DnsRecordType.A, request01.RecordType);
            Assert.Equal(1, request01.TTL);
            Assert.True(request01.Proxied);

            DnsRecordRequest request02 = new DnsRecordRequest(content, name, recordType);
            Assert.Equal(name, request02.Name);
            Assert.Equal(content, request02.Content);
            Assert.Equal(recordType, request02.RecordType);
            Assert.Equal(1, request02.TTL);
            Assert.True(request02.Proxied);

            DnsRecordRequest request03 = new DnsRecordRequest(content, name, proxied);
            Assert.Equal(name, request03.Name);
            Assert.Equal(content, request03.Content);
            Assert.Equal(DnsRecordType.A, request03.RecordType);
            Assert.Equal(1, request03.TTL);
            Assert.False(request03.Proxied);

            DnsRecordRequest request04 = new DnsRecordRequest(content, name, ttl);
            Assert.Equal(name, request04.Name);
            Assert.Equal(content, request04.Content);
            Assert.Equal(DnsRecordType.A, request04.RecordType);
            Assert.Equal(ttl, request04.TTL);
            Assert.True(request04.Proxied);

            DnsRecordRequest request05 = new DnsRecordRequest(content, name, recordType, proxied);
            Assert.Equal(name, request05.Name);
            Assert.Equal(content, request05.Content);
            Assert.Equal(recordType, request05.RecordType);
            Assert.Equal(1, request05.TTL);
            Assert.False(request05.Proxied);

            DnsRecordRequest request06 = new DnsRecordRequest(content, name, recordType, ttl);
            Assert.Equal(name, request06.Name);
            Assert.Equal(content, request06.Content);
            Assert.Equal(recordType, request06.RecordType);
            Assert.Equal(ttl, request06.TTL);
            Assert.True(request06.Proxied);

            DnsRecordRequest request07 = new DnsRecordRequest(content, name, ttl, proxied);
            Assert.Equal(name, request07.Name);
            Assert.Equal(content, request07.Content);
            Assert.Equal(DnsRecordType.A, request07.RecordType);
            Assert.Equal(ttl, request07.TTL);
            Assert.False(request07.Proxied);

            DnsRecordRequest request08 = new DnsRecordRequest(content, name, recordType ,ttl, proxied);
            Assert.Equal(name, request08.Name);
            Assert.Equal(content, request08.Content);
            Assert.Equal(recordType, request08.RecordType);
            Assert.Equal(ttl, request08.TTL);
            Assert.False(request08.Proxied);
        }

        [Fact]
        public void SetTTLTest()
        {
            string name = "sub.test.com";
            string content = "172.0.0.1";

            DnsRecordRequest request = new DnsRecordRequest(name, content);

            int correctTTL01 = 1;
            int correctTTL02 = 60;
            int correctTTL03 = 84600;
            int correctTTL04 = 3600;
            int invalidTTL01 = 0;
            int invalidTTL02 = 10;
            int invalidTTL03 = 90000;
            int invalidTTL04 = -1;

            request.TTL = correctTTL01;
            request.TTL = correctTTL02;
            request.TTL = correctTTL03;
            request.TTL = correctTTL04;

            Assert.Throws<ArgumentOutOfRangeException>(() => request.TTL = invalidTTL01);
            Assert.Throws<ArgumentOutOfRangeException>(() => request.TTL = invalidTTL02);
            Assert.Throws<ArgumentOutOfRangeException>(() => request.TTL = invalidTTL03);
            Assert.Throws<ArgumentOutOfRangeException>(() => request.TTL = invalidTTL04);
        }

        [Fact]
        public void SetNameTest()
        {
            string correctName01 = "sub.test.com";
            string correctName02 = GenerateLongString(255);
            string invalidName01 = null;
            string invalidName02 = GenerateLongString(256);

            string content = "172.0.0.1";

            DnsRecordRequest request01 = new DnsRecordRequest(correctName01, content);
            DnsRecordRequest request02 = new DnsRecordRequest(correctName02, content);
            
            Assert.Throws<ArgumentException>(() => request01.Name = invalidName01);
            Assert.Throws<ArgumentException>(() => request02.Name = invalidName02);
        }

        private string GenerateLongString(int length)
        {
            string resultString = "";

            for(int i = 0; i < length; i++)
            {
                resultString += "a";
            }

            return resultString;
        }
    }
}

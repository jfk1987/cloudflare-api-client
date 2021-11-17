using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlareApiClient
{
    public enum DnsRecordType
    {
        A,
        AAAA,
        TXT,
        MX,
        CNAME,
        SPF,
        SRV
    }

    public enum HttpMethod
    {
        GET,
        POST,
        PUT,
        DELETE,
        PATCH
    }
}

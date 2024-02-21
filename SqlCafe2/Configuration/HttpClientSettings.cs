using System;
using System.Collections.Generic;

namespace SqlCafe2.Configuration
{
    public class HttpClientSettings : IHttpClientSettings
    {
        public HttpClientSettings(string baseAddress, int timeout, int retry)
        {
            BaseAddress = baseAddress;
            Timeout = timeout;
            Retry = retry;
        }

        public string BaseAddress { get; }

        public int Timeout { get; }

        public int Retry { get; }

        public IEnumerable<IHeader> DefaultHeaders { get; } = new IHeader[0];
    }
}
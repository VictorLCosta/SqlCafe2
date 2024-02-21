#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SqlCafe2.Configuration
{
    public class HttpClientElement : ElementBase, IHttpClientSettings
    {
        private static ConfigurationProperty headersCollection = new("defaultRequestHeaders", typeof(HeaderElementCollection), new HeaderElementCollection(), ConfigurationPropertyOptions.None);

        public HttpClientElement()
        {
            Properties.Add(headersCollection);
        }

        [ConfigurationProperty("baseAddress", IsRequired = true)]
        public string BaseAddress => (string)this["baseAddress"];

        public HeaderElementCollection DefaultRequestHeaders => (HeaderElementCollection)this["defaultRequestHeaders"];

        [ConfigurationProperty("timeout", IsRequired = false, DefaultValue = 100)]
        public int Timeout => (int)this["timeout"];

        [ConfigurationProperty("retry", IsRequired = false, DefaultValue = 100)]
        public int Retry => (int)this["retry"];

        private IEnumerable<IHeader> _defaultHeaders = new IHeader[0];

        public IEnumerable<IHeader> DefaultHeaders
        {
            get
            {
                var headersList = DefaultRequestHeaders.ToList();
                return _defaultHeaders ??= headersList;
            }
            set => _defaultHeaders = value;
        }
    }
}
#endif

#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SqlCafe2.Configuration
{
    public class HttpClientElement : ElementBase, IHttpClientSettings
    {
        [ConfigurationProperty("baseAddress", IsRequired = true)]
        public string BaseAddress => (string)this["baseAddress"];

        [ConfigurationProperty("defaultHeaders", IsDefaultCollection = false)]
        public HeaderElementCollection Headers => (HeaderElementCollection)this["defaultHeaders"];

        [ConfigurationProperty("timeout", IsRequired = false, DefaultValue = 100)]
        public int Timeout => (int)this["timeout"];

        [ConfigurationProperty("retry", IsRequired = false, DefaultValue = 100)]
        public int Retry => (int)this["retry"];

        private IEnumerable<IHeader> _defaultHeaders = Array.Empty<IHeader>();

        public IEnumerable<IHeader> DefaultHeaders
        {
            get
            {
                var headersList = Headers.ToList();
                return _defaultHeaders ??= headersList;
            }
            set => _defaultHeaders = value;
        }
    }
}
#endif

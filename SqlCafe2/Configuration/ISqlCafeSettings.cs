using System.Collections.Generic;

namespace SqlCafe2.Configuration
{
    public interface ISqlCafeSettings
    {
        public string DefaultProvider { get; }
        public IHttpClientSettings? HttpClientSettings { get; }

        public IEnumerable<IConnectionString> ConnectionStringsSettings { get; }
    }
}
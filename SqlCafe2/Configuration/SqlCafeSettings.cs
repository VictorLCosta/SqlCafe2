using System.Collections.Generic;

namespace SqlCafe2.Configuration
{
    public class SqlCafeSettings : ISqlCafeSettings
    {
        private readonly IConnectionString _connectionString;

        public SqlCafeSettings(string connectionString, string name, string providerName, IHttpClientSettings? httpClientSettings = null)
        {
            _connectionString = new ConnectionStringSettings(connectionString, name, providerName);
            HttpClientSettings = httpClientSettings;
        }

        public string DefaultProvider => ProviderName.SqlServer;

        public IHttpClientSettings? HttpClientSettings { get; }

        public bool HasHttpClient => HttpClientSettings != null;

        public IEnumerable<IConnectionString> ConnectionStringsSettings
        {
            get
            {
                yield return _connectionString;
            }
        }
    }
}
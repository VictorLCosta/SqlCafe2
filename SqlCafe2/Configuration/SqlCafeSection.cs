#if NETFRAMEWORK
using System.Collections.Generic;
using System.Configuration;
using System.Security;

namespace SqlCafe2.Configuration
{
    public class SqlCafeSection : ConfigurationSection, ISqlCafeSettings
    {
        private static readonly ConfigurationPropertyCollection properties = new();

        private static readonly ConfigurationProperty connectionStrings = new("connectionStringsEx", typeof(ConnectionStringElementCollection), new ConnectionStringElementCollection(), ConfigurationPropertyOptions.None);
        private static readonly ConfigurationProperty httpClient = new("httpClient", typeof(HttpClientElement), new HttpClientElement(), ConfigurationPropertyOptions.None);

        public SqlCafeSection()
        {
            properties.Add(connectionStrings);
            properties.Add(httpClient);
        }

        private readonly static SqlCafeSection? instance;

        public static SqlCafeSection? Instance 
        {
            get 
            {
                if (instance == null)
                {
                    try 
                    {
                        return (SqlCafeSection)ConfigurationManager.GetSection("sqlcafe") ?? new SqlCafeSection();
                    }
                    catch (SecurityException)
                    {
                        return null;
                    }
                }
                return instance; 
            } 
        }

        protected override ConfigurationPropertyCollection Properties => properties;

        public ConnectionStringElementCollection ConnectionStrings
        {
            get { return (ConnectionStringElementCollection)base[connectionStrings]; }
            set { base[connectionStrings] = value; }
        }

        public HttpClientElement? HttpClient 
        {
            get { return (HttpClientElement?)base[httpClient]; } 
            set { base[httpClient] = value; }
        }

        public string DefaultProvider => ProviderName.SqlServer;

        public IHttpClientSettings? HttpClientSettings => HttpClient;

        public IEnumerable<IConnectionString> ConnectionStringsSettings
        {
            get 
            {
                foreach (ConnectionStringElement item in ConnectionStrings)
                {
                    yield return item;
                }
            }
        }

    }
}
#endif
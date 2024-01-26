#if NETFRAMEWORK
using System.Configuration;

namespace SqlCafe2.Configuration
{
    /// <summary>
    /// Represents the configuration settings for SqlCafe.
    /// </summary>
    public class SqlCafeSettings : ConfigurationSection
    {
        private static readonly ConfigurationPropertyCollection properties = new();

        private static readonly ConfigurationProperty connectionStrings = new("connectionStringsEx", typeof(ConnectionStringExCollection), new ConnectionStringExCollection(), ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty httpClient = new("httpClient", typeof(HttpClientElement), new HttpClientElement(), ConfigurationPropertyOptions.None);

        public SqlCafeSettings()
        {
            properties.Add(connectionStrings);
            properties.Add(httpClient);
        }

        private readonly static SqlCafeSettings? instance;

        public static SqlCafeSettings? Instance 
        {
            get 
            {
                if (instance == null)
                {
                    return (SqlCafeSettings)ConfigurationManager.GetSection("sqlcafe") ?? new SqlCafeSettings();
                }
                return instance; 
            } 
        }

        protected override ConfigurationPropertyCollection Properties => properties;

        public ConnectionStringExCollection ConnectionStrings
        {
            get { return (ConnectionStringExCollection)this[connectionStrings]; }
            set { this[connectionStrings] = value; }
        }

        public HttpClientElement HttpClient 
        {
            get { return (HttpClientElement)this[httpClient]; } 
            set { this[httpClient] = value; }
        }
    }
}
#endif
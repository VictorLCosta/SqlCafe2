using System.Configuration;

namespace SqlCafe2.Configuration
{
    public class ConnectionStringElement : ElementBase
    {
        [ConfigurationProperty("connectionString", IsRequired = true)]
        public string Source 
        { 
            get => (string)this["connectionString"]; 
            set => this["connectionString"] = value; 
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name 
        {
            get => (string)this["name"];
            set => this["name"] = value;
        }

        [ConfigurationProperty("providerName", IsRequired = true)]
        public string ProviderName 
        { 
            get => (string)this["providerName"]; 
            set => this["providerName"] = value; 
        }
    }
}
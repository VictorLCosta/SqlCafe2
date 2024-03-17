#if NETFRAMEWORK
using System;
using System.Configuration;

namespace SqlCafe2.Configuration
{
    public class ConnectionStringElement : ElementBase, IConnectionString
    {
        [ConfigurationProperty("source", IsRequired = true)]
        public string Source
        {
            get => (string)this["source"];
            set => this["source"] = value;
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

        [ConfigurationProperty("isGlobal", IsRequired = false, DefaultValue = false)]
        public bool IsGlobal
        {
            get => Convert.ToBoolean(Attributes["isGlobal"]);
            set => this["isGlobal"] = value;
        }
    }
}
#endif
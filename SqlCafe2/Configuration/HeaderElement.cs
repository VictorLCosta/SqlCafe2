#if NETFRAMEWORK
using System.Configuration;

namespace SqlCafe2.Configuration
{
    public class HeaderElement : ElementBase, IHeader
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key => (string)this["key"];

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value => (string)this["value"];
    }
}
#endif
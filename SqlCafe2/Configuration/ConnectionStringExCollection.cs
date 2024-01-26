#if NETFRAMEWORK
using System.Configuration;

namespace SqlCafe2.Configuration
{
    [ConfigurationCollection(typeof(ConnectionStringElement), AddItemName = "add")]
    public class ConnectionStringExCollection : ElementBaseCollection<ConnectionStringElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionStringElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionStringElement)element).Name;
        }
    }
}
#endif
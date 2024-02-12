#if NETFRAMEWORK
using System.Configuration;

namespace SqlCafe2.Configuration
{
    [ConfigurationCollection(typeof(ConnectionStringElement), AddItemName = "add")]
    public class ConnectionStringElementCollection : ElementCollectionBase<ConnectionStringElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionStringElement();
        }

        protected override object GetElementKey(ConnectionStringElement element)
        {
            return element.Name;
        }
    }
}
#endif
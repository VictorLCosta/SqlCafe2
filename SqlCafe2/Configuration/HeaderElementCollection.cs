#if NETFRAMEWORK
using System.Configuration;

namespace SqlCafe2.Configuration
{
    [ConfigurationCollection(typeof(HeaderElement), AddItemName = "add")]
    public class HeaderElementCollection : ElementCollectionBase<HeaderElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new HeaderElement();
        }

        protected override object GetElementKey(HeaderElement element)
        {
            return element.Key;
        }
    }
}
#endif
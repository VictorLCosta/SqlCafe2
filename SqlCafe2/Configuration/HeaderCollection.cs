#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlCafe2.Configuration
{
    [ConfigurationCollection(typeof(HeaderElement), AddItemName = "add")]
    public class HeaderCollection : ElementBaseCollection<HeaderElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new HeaderElement();
        }

        protected override object GetElementKey(HeaderElement element)
        {
            return ((HeaderElement)element).Key;
        }
    }
}
#endif
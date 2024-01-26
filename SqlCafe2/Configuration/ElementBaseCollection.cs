using System;
using System.Configuration;

namespace SqlCafe2.Configuration
{
    public class ElementBaseCollection<T> : ConfigurationElementCollection
        where T : ElementBase, new()
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return GetElementKey((T)element);
        }
    }
}
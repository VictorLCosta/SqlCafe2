#if NETFRAMEWORK
using System.Collections.Generic;
using System.Configuration;

namespace SqlCafe2.Configuration
{
    public abstract class ElementCollectionBase<T> : ConfigurationElementCollection
        where T : ElementBase, new()
    {
        protected override ConfigurationElement CreateNewElement()
		{
			return new T();
		}

        protected abstract object GetElementKey(T element);

        protected sealed override object GetElementKey(ConfigurationElement element)
		{
			return GetElementKey((T)element);
		}

        public new T this[string name]
		{
			get { return (T)BaseGet(name); }
		}

        public  T this[int index]
		{
			get { return (T)BaseGet(index); }
		}

        public virtual List<T> ToList()
        {
            List<T> list = new();

            foreach (T item in this)
            {
                list.Add(item);
            }

            return list;
        }
    }
}
#endif
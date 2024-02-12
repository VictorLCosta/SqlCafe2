#if NETFRAMEWORK
using System.Configuration;
using System.Collections.Specialized;
using System;

namespace SqlCafe2.Configuration
{
    public abstract class ElementBase : ConfigurationElement
    {
        private readonly ConfigurationPropertyCollection _properties = new ConfigurationPropertyCollection();
		protected override ConfigurationPropertyCollection Properties => _properties;

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
		{
			var property = new ConfigurationProperty(name, typeof(string), value);

			_properties.Add(property);

			base[property] = value;

			Attributes.Add(name, value);

			return true;
		}

        public NameValueCollection Attributes { get; } = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
    }
}
#endif
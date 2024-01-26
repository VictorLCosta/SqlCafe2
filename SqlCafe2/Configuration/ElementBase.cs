#if NETFRAMEWORK
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace SqlCafe2.Configuration
{
    public class ElementBase : ConfigurationElement
    {
        private readonly ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();
		protected override ConfigurationPropertyCollection Properties => properties;

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
		{
			var property = new ConfigurationProperty(name, typeof(string), value);

			properties.Add(property);

			base[property] = value;

			Attributes.Add(name, value);

			return true;
		}

        public NameValueCollection Attributes { get; } = new NameValueCollection(StringComparer.OrdinalIgnoreCase);

    }
}
#endif
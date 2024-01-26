#if NETFRAMEWORK
using System;
using System.Configuration;

namespace SqlCafe2.Configuration
{
    public class HttpClientElement : ElementBase
    {
        private static ConfigurationProperty baseAddress = new ConfigurationProperty("baseAddress", typeof(BaseAddressElement), new BaseAddressElement(), ConfigurationPropertyOptions.IsRequired);
        private static ConfigurationProperty timeout = new ConfigurationProperty("timeout", typeof(TimeoutElement), new TimeoutElement(), ConfigurationPropertyOptions.None);
        private static ConfigurationProperty retry = new ConfigurationProperty("retry", typeof(RetryElement), new RetryElement(), ConfigurationPropertyOptions.None);
        private static ConfigurationProperty headersCollection = new ConfigurationProperty("defaultRequestHeaders", typeof(HeaderCollection), new HeaderCollection(), ConfigurationPropertyOptions.None);

        public HttpClientElement()
        {
            Properties.Add(baseAddress);
            Properties.Add(timeout);
            Properties.Add(retry);
            Properties.Add(headersCollection);
        }

        public BaseAddressElement BaseAddress
        {
            get => (BaseAddressElement)this["baseAddress"]; 
            set { this["baseAddress"] = value; }
        }

        public TimeoutElement Timeout
        {
            get { return (TimeoutElement)this["timeout"]; }
            set { this["timeout"] = value; }
        }

        [IntegerValidator(MinValue = 0)]
        public RetryElement Retry
        {
            get { return (RetryElement)this["retry"]; }
            set { this["retry"] = value; }
        }

        public HeaderCollection DefaultRequestHeaders
        {
            get { return (HeaderCollection)this["defaultRequestHeaders"]; }
            set { this["defaultRequestHeaders"] = value; }
        }
    }

    public class BaseAddressElement : ElementBase
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get => (string)base["value"];
        }
    }

    public class TimeoutElement : ElementBase
    {
        [ConfigurationProperty("value", IsRequired = false)]
        public TimeSpan Value
        {
            get => (TimeSpan)base["value"];
        }
    }

    public class RetryElement : ElementBase
    {
        [ConfigurationProperty("value", IsRequired = false)]
        public int Value
        {
            get => (int)base["value"];
        }
    }
}
#endif
using System.Collections.Generic;

namespace SqlCafe2.Configuration
{
    public interface IHttpClientSettings
    {
        public string BaseAddress { get; }
        public int Timeout { get; }
        public int Retry { get; }

        public IEnumerable<IHeader> DefaultHeaders { get; }
    }
}
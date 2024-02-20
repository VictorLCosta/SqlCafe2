using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SqlCafe2.Remote
{
    public interface ICafeHttpClient
    {
        public Uri BaseAddress { get; set; }

        public HttpClient BaseClient { get; }

        public TimeSpan Timeout { get; set; }
    }
}
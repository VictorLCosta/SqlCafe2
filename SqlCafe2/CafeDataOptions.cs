using System.Data.Common;
using SqlCafe2.DataProviders;

namespace SqlCafe2
{
    public sealed record CafeDataOptions
    {
        public CafeDataOptions(string? providerName, IBaseProvider? provider, bool isAutoCloseConnection, bool? disposeConnection, DbConnection? connection, string? connectionString)
        {
            ProviderName = providerName;
            Provider = provider;
            IsAutoCloseConnection = isAutoCloseConnection;
            DisposeConnection = disposeConnection;
            Connection = connection;
            ConnectionString = connectionString;
        }

        public string? ProviderName { get; }
        public IBaseProvider? Provider { get; }
        public bool IsAutoCloseConnection { get; }
        public bool? DisposeConnection { get; }
        public DbConnection? Connection { get; }
        public string? ConnectionString { get; set; }
        public int? CommandTimeout { get; set; }
    }
}
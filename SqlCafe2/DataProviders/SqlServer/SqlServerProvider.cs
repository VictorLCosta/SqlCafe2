using System.Data.Common;

#if NETFRAMEWORK
using System.Data.SqlClient;
#else
using Microsoft.Data.SqlClient;
#endif

namespace SqlCafe2.DataProviders.SqlServer
{
    public class SqlServerProvider : BaseProvider, IBaseProvider
    {
        public override string ProviderName => "SqlServer";

        protected override DbConnection CreateConnectionInternal(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
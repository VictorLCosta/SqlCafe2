using System.Data;
using System.Data.Common;
using ImmediateReflection;
using System;


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

        protected override DbCommand InitCommandInternal(DbCommand command, string commandText, CommandType commandType, int commandTimeout, object? parameters = null)
        {
            var cmd = (SqlCommand)command;

            cmd.CommandText = commandText;
            cmd.CommandTimeout = commandTimeout;
            cmd.CommandType = commandType;

            if(parameters != null)
            {
                
            }

            cmd.Prepare();

            return cmd;
        }
    }
}
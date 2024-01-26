using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SqlCafe2.DataProviders
{
    public abstract class BaseProvider : IBaseProvider
    {
        public bool IsTransactionSupported => throw new NotImplementedException();

        public DbConnection CreateConnection(string connectionString) => CreateConnectionInternal(connectionString);

        protected abstract DbConnection CreateConnectionInternal(string connectionString);

        public DbCommand InitCommand(string commandText, CommandType commandType, object? parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using SqlCafe2.Sql;

namespace SqlCafe2.DataProviders
{
    public abstract class BaseProvider : IBaseProvider
    {
        public abstract string ProviderName { get; }

        public ISqlBuilder sqlBuider => throw new NotImplementedException();

        public SqlProviderFlags ProviderFlags => throw new NotImplementedException();

        public DbConnection CreateConnection(string connectionString) => CreateConnectionInternal(connectionString);

        protected abstract DbConnection CreateConnectionInternal(string connectionString);

        public void InitCommand(ref DbCommand command, string commandText, CommandType commandType, int commandTimeout, object? parameters = null) 
            => InitCommandInternal(ref command, commandText, commandType, commandTimeout, parameters);

        protected abstract void InitCommandInternal(ref DbCommand command, string commandText, CommandType commandType, int commandTimeout, object? parameters = null);

    }
}
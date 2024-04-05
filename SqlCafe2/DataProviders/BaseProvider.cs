using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using ImmediateReflection;
using SqlCafe2.Enums;
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

        public DbCommand InitCommand(DbCommand command, string commandText, CommandType commandType, int commandTimeout, object? parameters = null) 
            => InitCommandInternal(command, commandText, commandType, commandTimeout, parameters);

        protected abstract DbCommand InitCommandInternal(DbCommand command, string commandText, CommandType commandType, int commandTimeout, object? parameters = null);

        protected virtual DbCafeParameter[] GetParameters(object? parameters)
        {
            ObjectWrapper wrapper = new(parameters);

            return wrapper
                .GetProperties()
                .Select(p => new DbCafeParameter(p.Name, DataType.Varchar, p.GetValue(parameters), "", 100))
                .ToArray();
        }
    }
}
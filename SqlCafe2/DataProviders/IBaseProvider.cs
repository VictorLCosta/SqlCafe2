using System.Data;
using System.Data.Common;
using SqlCafe2.Sql;

namespace SqlCafe2.DataProviders
{
    public interface IBaseProvider
    {
        string ProviderName { get; }

        ISqlBuilder sqlBuider { get; }

        SqlProviderFlags ProviderFlags { get; }

        DbConnection CreateConnection(string connectionString);

        DbCommand InitCommand(DbCommand command, string commandText, CommandType commandType, int commandTimeout, object? parameters = null);
    }
}
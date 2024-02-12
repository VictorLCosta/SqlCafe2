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

        DbCommand InitCommand(string commandText, CommandType commandType, object? parameters = null);
        DbConnection CreateConnection(string connectionString);
    }
}
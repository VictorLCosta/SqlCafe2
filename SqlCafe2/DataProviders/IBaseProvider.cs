

using System.Data;
using System.Data.Common;

namespace SqlCafe2.DataProviders
{
    public interface IBaseProvider
    {
        bool IsTransactionSupported { get; }

        DbCommand InitCommand(string commandText, CommandType commandType, object? parameters = null);
        DbConnection CreateConnection(string connectionString);
    }
}
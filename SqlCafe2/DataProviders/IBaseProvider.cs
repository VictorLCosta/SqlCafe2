

using System.Data;
using System.Data.Common;

namespace SqlCafe2.DataProviders
{
    public interface IBaseProvider
    {
        bool IsTransactionSupported { get; }

        DbCommand InitCommand(CommandType commandType, string commandText);
        DbConnection CreateConnection(string connectionString);
    }
}
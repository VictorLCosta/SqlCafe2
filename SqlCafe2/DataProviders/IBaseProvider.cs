

using System.Data;
using System.Data.Common;

namespace SqlCafe2.DataProviders
{
    public interface IBaseProvider
    {
        bool IsTransactionSupported { get; }

        DbCommand InitCommand(ref string commandText, CommandType commandType);
        DbConnection CreateConnection(string connectionString);
    }
}
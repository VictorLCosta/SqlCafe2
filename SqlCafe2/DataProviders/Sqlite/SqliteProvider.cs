using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace SqlCafe2.DataProviders.Sqlite
{
    public class SqliteProvider : BaseProvider, IBaseProvider
    {
        public override string ProviderName => "Sqlite";

        protected override DbConnection CreateConnectionInternal(string connectionString)
            => new SQLiteConnection(connectionString);

        protected override DbCommand InitCommandInternal(DbCommand command, string commandText, CommandType commandType, int commandTimeout, object? parameters = null)
        {
            var cmd = (SQLiteCommand)command;

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
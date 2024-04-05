using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace SqlCafe2
{
    public partial class CafeContext : ICafeContext
    {
        public async Task<int> ExecuteNonQueryAsync(string command, object? parameters = null)
        {
            try
            {
                var cmd = Provider.InitCommand((DbCommand)Connection.CreateCommand(), command, CommandType.Text, 100, parameters);

                return await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
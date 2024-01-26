using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SqlCafe2
{
    public partial class CafeContext : ICafeContext
    {
        public async Task<int> ExecuteNonQueryAsync(string command, object? parameters = null)
        {
            try
            {
                var cmd = Provider.InitCommand(command, CommandType.Text, parameters);

                return await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
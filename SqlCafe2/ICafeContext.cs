using System;
using System.Data.Common;
using System.Threading.Tasks;
using SqlCafe2.DataProviders;

namespace SqlCafe2
{
    public interface ICafeContext : IDisposable, ICloneable
    #if NATIVE_ASYNC
        , IAsyncDisposable
    #else
        , Async.IAsyncDisposable
    #endif
    {
        internal CafeDataOptions Options { get; }

        int ExecuteNonQuery();
        object? ExecuteScalar(DbCommand command);

        void ExecuteReader();

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        void Close();
        Task CloseAsync();
    }
}
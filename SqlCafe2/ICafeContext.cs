using System;
using System.Data;
using System.Data.Common;

namespace SqlCafe2
{
    public interface ICafeContext : IDisposable, ICloneable
    #if NATIVE_ASYNC
        , IAsyncDisposable
    #else
        , Async.IAsyncDisposable
    #endif
    {
        CafeDataOptions Options { get; }

        int ExecuteNonQuery(string command);
        object? ExecuteScalar(DbCommand command);

        IDataReader GetDataReader(string command);
        DataTable GetDataTable(string command);
        DataTable GetDataTable(string command, object parameters);

        void BeginTransaction();
        void BeginTransaction(IsolationLevel iso);
        void CommitTransaction();
        void RollbackTransaction();

        void CheckConnection();
        void Open();
        void Close();

        bool UseTran(Action action, Action<Exception>? errorCallback = null);
        T UseTran<T>(Func<T> action, Action<Exception>? errorCallback = null);

    }
}
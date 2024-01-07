using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using SqlCafe2.Async;
using SqlCafe2.DataProviders;

namespace SqlCafe2
{
    public class CafeContext : ICafeContext
    {
        private bool _disposed;

        #region Constructors

        public CafeContext(string connectionString)
        {
            
        }

        public CafeContext(IBaseProvider provider, string connectionString)
        {
             
        }

        public CafeContext(string providerName, string connectionString, Func<CafeDataOptions, CafeDataOptions> optionsSetter)
        {
            
        }

        public CafeContext(IBaseProvider provider, string connectionString, Func<CafeDataOptions, CafeDataOptions> optionsSetter)
        {
            
        }

        #endregion

        #region Properties

        public CafeDataOptions Options { get; }

        public IBaseProvider Provider { get; set; }

        public IDbConnection Connection { get; set; }

        public string? ConnectionString { get; }

        public int? CommandTimeout { get; set; }

        #endregion

        #region Connection

        public virtual void CheckConnection()
        {
            if (Connection.State != ConnectionState.Open)
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        public virtual void Open()
        {
            CheckConnection();
        }

        public virtual void Close()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Core

        public int ExecuteNonQuery(string command)
        {
            throw new NotImplementedException();
        }

        public object? ExecuteScalar(DbCommand command)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetDataReader(string command)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string command)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string command, object parameters)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Transaction

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction(IsolationLevel iso)
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Use

        bool ICafeContext.UseTran(Action action, Action<Exception>? errorCallback)
        {
            throw new NotImplementedException();
        }

        T ICafeContext.UseTran<T>(Func<T> action, Action<Exception>? errorCallback)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Dispose

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        Task IAsyncDisposable.DisposeAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        public object Clone()
        {
            throw new NotImplementedException();
        }

    }
}
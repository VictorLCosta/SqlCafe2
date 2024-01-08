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
            
        }

        #endregion

        #region Core

        public virtual int ExecuteNonQuery(string command, object? parameters = null)
        {
            try
            {
                var cmd = Provider.InitCommand(ref command, CommandType.Text);

                return cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public object? ExecuteScalar(DbCommand command)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetDataReader(string command)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string command, object? parameters = null)
        {
            try
            {
                DataTable dtReturn = new();

                using DbCommand cmd = Provider.InitCommand(ref command, CommandType.Text);

                using IDataReader reader = cmd.ExecuteReader();

                dtReturn.Load(reader);

                return dtReturn;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        #endregion

        #region Transaction

        public void BeginTransaction()
        {
            CheckConnection();
            Connection.BeginTransaction();
        }

        public void BeginTransaction(IsolationLevel iso)
        {
            CheckConnection();
            Connection.BeginTransaction(iso);
        }

        public void CommitTransaction()
        {
            CheckConnection();
        }

        public void RollbackTransaction()
        {
            CheckConnection();
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #if NATIVE_ASYNC
        public virtual ValueTask DisposeAsync()
        #else
        public virtual Task DisposeAsync()
        #endif
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
using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using SqlCafe2.DataProviders;
using SqlCafe2.Remote;

namespace SqlCafe2
{
    public partial class CafeContext : ICafeContext
    {
        #region Fields

        private bool _disposed;

        #endregion

        #region Constructors

        public CafeContext()
        {
            UseDefaultConfiguration();
        }

        public CafeContext(string connectionString)
        {
            
        }

        public CafeContext(IBaseProvider provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
            Connection = Provider.CreateConnection(connectionString);
        }

        public CafeContext(string providerName, string connectionString, Func<CafeDataOptions> optionsSetter)
        {
            Provider = GetDataProvider(providerName);
            ConnectionString = connectionString;
            Connection = Provider.CreateConnection(connectionString);

            Options =  optionsSetter.Invoke();
        }

        public CafeContext(Func<CafeDataOptions> optionsSetter)
        {
            
        }

        #endregion

        #region Properties

        public CafeDataOptions Options { get; private set; }

        public IDbConnection Connection { get; private set; }

        public IDbTransaction? Transaction { get; private set; }

        public int? CommandTimeout { get; private set; }

        public string ConnectionStringName { get; private set; } = string.Empty;

        public string ConnectionString { get; private set; }

        public IBaseProvider Provider { get; internal set; }

        public ICafeHttpClient? HttpClient { get; private set; }

        public bool HasHttpClient => HttpClient != null;

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
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public virtual void Open()
        {
            CheckConnection();
        }

        public virtual void Close()
        {
            if (this.Transaction != null)
            {
                this.Transaction = null;
            }
            if (this.Connection != null && this.Connection.State == ConnectionState.Open)
            {
                this.Connection.Close();
                this.Connection.Dispose();
            }
        }

        #endregion

        #region Core

        public virtual int ExecuteNonQuery(string command, object? parameters = null)
        {
            try
            {
                using DbCommand cmd = Provider.InitCommand((DbCommand)Connection.CreateCommand(), command, CommandType.Text, 100, parameters);

                int result = cmd.ExecuteNonQuery();

                if(Options.IsAutoCloseConnection) Close();

                return result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public object? GetScalar(string command, object? parameters = null)
        {
            try
            {
                using DbCommand cmd = Provider.InitCommand((DbCommand)Connection.CreateCommand(), command, CommandType.Text, 100);

                return cmd.ExecuteScalar();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public IDataReader GetDataReader(string command)
        {
            try
            {
                using DbCommand cmd = Provider.InitCommand((DbCommand)Connection.CreateCommand(), command, CommandType.Text, 100);

                IDataReader reader = cmd.ExecuteReader();

                return reader;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public DataTable GetDataTable(string command, object? parameters = null)
        {
            try
            {
                DataTable dtReturn = new();

                Open();

                using DbCommand cmd = Provider.InitCommand((DbCommand)Connection.CreateCommand(), command, CommandType.Text, 100, parameters);

                using IDataReader reader = cmd.ExecuteReader();

                dtReturn.Load(reader);

                Close();

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
            Transaction ??= Connection.BeginTransaction();
        }

        public void BeginTransaction(IsolationLevel iso)
        {
            CheckConnection();
            Transaction ??= Connection.BeginTransaction(iso);
        }

        public void CommitTransaction()
        {
            Transaction?.Commit();
            Transaction = null;
        }

        public void RollbackTransaction()
        {
            Transaction?.Rollback();
            Transaction = null;
        }

        #endregion

        #region Use

        bool ICafeContext.UseTran(Action action, Action<Exception>? errorCallback)
        {
            try
            {
                BeginTransaction();
                action?.Invoke();
                CommitTransaction();

                return true;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                errorCallback?.Invoke(ex);
            }

            return false;
        }

        T ICafeContext.UseTran<T>(Func<T> action, Action<Exception>? errorCallback)
        {
            T result = Activator.CreateInstance<T>();

            try
            {
                BeginTransaction();
                if(action != null) result = action.Invoke();
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                errorCallback?.Invoke(ex);
            }

            return result;
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;

                Connection.Dispose();
                Transaction?.Dispose();
            }
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
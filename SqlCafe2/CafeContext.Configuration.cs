using System;
using System.Collections.Generic;
using SqlCafe2.Common;
using SqlCafe2.Configuration;
using SqlCafe2.DataProviders;
using SqlCafe2.DataProviders.SqlServer;

namespace SqlCafe2
{
    public partial class CafeContext : ICafeContext
    {

        private static readonly SmallDictionary<string, IBaseProvider> _providers = new(5);

        private static ISqlCafeSettings? _defaultSettings;

        public static ISqlCafeSettings? DefaultSettings
        {
            #if NETFRAMEWORK
            get => _defaultSettings ??= SqlCafeSection.Instance;
            #else
            get => _defaultSettings;
            #endif
            set => _defaultSettings = value;
        }

        private static SmallDictionary<string, IConnectionString> _connectionStrings = new();
        
        private static IConnectionString? _defaultConnectionString = default;
        public static IConnectionString? DefaultConnectionString
        {
            get => _defaultConnectionString;
            set => _defaultConnectionString = value;
        }

        static CafeContext()
        {
            _providers.Add("SqlServer", new SqlServerProvider());
        }

        public static IBaseProvider GetDataProvider(string providerName)
        {
            if (_providers.TryGetValue(providerName, out var provider))
            {
                return provider;
            }

            throw new Exception($"Provider '{providerName}' not found.");
        }

        public static void SetConnectionStrings(IEnumerable<IConnectionString> connectionStrings)
        {
            foreach (var connectionString in connectionStrings)
            {
                if(connectionString.IsGlobal)
                {
                    _defaultConnectionString = connectionString; 
                    _connectionStrings.Add(connectionString.Name, connectionString);
                }
                else
                    _connectionStrings.Add(connectionString.Name, connectionString);
            }
        }

        public static string? TryGetConnectionString(string? name)
        {
            string key = name ?? DefaultConnectionString?.Name ?? string.Empty;

            if (_connectionStrings.TryGetValue(key, out var connectionString))
            {
                return connectionString.Source;
            }

            return null;
        }

        public virtual void UseDefaultConfiguration()
        {
            SetConnectionStrings(DefaultSettings?.ConnectionStringsSettings ?? new List<IConnectionString>());

            ConnectionStringName = DefaultConnectionString?.Name ?? string.Empty;
            ConnectionString = TryGetConnectionString(ConnectionStringName) ?? string.Empty;
            Provider = GetDataProvider(DefaultConnectionString!.ProviderName);

            if(DefaultSettings?.HttpClientSettings != null)
            {
                
            }
        }

        public virtual void OnConfiguring()
        {
            
        }

    }
}
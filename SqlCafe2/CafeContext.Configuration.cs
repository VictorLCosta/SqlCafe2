using System;
using SqlCafe2.Common;
using SqlCafe2.Configuration;
using SqlCafe2.DataProviders;

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

        static CafeContext()
        {
            
        }

        private string? _connectionString;
        public string ConnectionString 
        { 
            get => _connectionString!;
            set => _connectionString = value;
        }

        private IBaseProvider? _provider;
        public IBaseProvider Provider 
        { 
            get
            {
                var provider = _provider ??= GetDataProvider(DefaultSettings?.DefaultProvider ?? "SqlServer");

                return provider;
            }
        }

        public static IBaseProvider GetDataProvider(string providerName)
        {
            if (_providers.TryGetValue(providerName, out var provider))
            {
                return provider;
            }

            throw new Exception($"Provider '{providerName}' not found.");
        }

        public virtual void UseDefaultConfiguration()
        {

        }

        public virtual void OnConfiguring()
        {
            
        }
    }
}
namespace SqlCafe2.Configuration
{
    public class ConnectionStringSettings : IConnectionString
    {
        public ConnectionStringSettings(string source, string name, string providerName)
        {
            Source = source;
            Name = name;
            ProviderName = providerName;
        }

        public string Source { get; }

        public string Name { get; }

        public string ProviderName { get; }

        public bool IsGlobal => false;
    }
}
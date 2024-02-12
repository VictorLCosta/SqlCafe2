namespace SqlCafe2.Configuration
{
    public interface IConnectionString
    {
        public string Source { get; }
        public string Name { get; }
        public string ProviderName { get; }
        public bool IsGlobal { get; }
    }
}
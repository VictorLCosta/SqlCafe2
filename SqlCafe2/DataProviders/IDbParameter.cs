using SqlCafe2.Enums;

namespace SqlCafe2.DataProviders
{
    public class IDbParameter
    {
        public IDbParameter()
        {
            
        }

        public IDbParameter(string name, object? value)
        {
            Name = name;
            Value = value;
        }

        public IDbParameter(string name, DataType dataType, object value)
        {
            Name = name;
            DataType = dataType;
            Value = value;
        }

        public IDbParameter(string name, DataType dataType, object value, string direction)
        {
            Name = name;
            DataType = dataType;
            Value = value;
            Direction = direction;
        }

        public IDbParameter(string name, DataType dataType, object value, string direction, string dbType)
        {
            Name = name;
            DataType = dataType;
            Value = value;
            Direction = direction;
            DbType = dbType;
        }

        public DataType DataType { get; set; }

        public string? DbType { get; set; }

        public string? Direction { get; set; }

        public string? Name { get; set; }

        public int? Precision { get; set; }

        public int? Scale { get; set; }

        public int? Size { get; set; }

        public object? Value { get; set; }
    }
}
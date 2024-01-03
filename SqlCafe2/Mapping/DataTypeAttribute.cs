using System;
using SqlCafe2.Enums;

namespace SqlCafe2.Mapping
{   
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class DataTypeAttribute : Attribute
    {
        public DataTypeAttribute(DataType dataType)
        {
            DataType = dataType;
        }

        public DataTypeAttribute(string dbType)
        {
            DbType = dbType;
        }

        public DataTypeAttribute(DataType dataType, string dbType)
        {
            DataType = dataType;
            DbType = dbType;
        }

        public DataType? DataType { get; set; }

        public string DbType { get; set; }

    }
}
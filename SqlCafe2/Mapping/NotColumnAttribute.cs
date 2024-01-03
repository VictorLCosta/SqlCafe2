using System;

namespace SqlCafe2.Mapping
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class NotColumnAttribute : ColumnAttribute
    {
        public NotColumnAttribute()
        {
            IsColumn = false;
        }
    }
}
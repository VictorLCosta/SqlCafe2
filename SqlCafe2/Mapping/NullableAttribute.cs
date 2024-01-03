using System;

namespace SqlCafe2.Mapping
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class NullableAttribute : Attribute
    {
        public NullableAttribute()
        {
            CanBeNull = true;
        }

        public NullableAttribute(bool isNullable)
        {
            CanBeNull = isNullable;
        }

        public bool CanBeNull { get; set; }
    }
}
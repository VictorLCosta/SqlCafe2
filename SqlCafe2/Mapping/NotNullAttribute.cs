using System;

namespace SqlCafe2.Mapping
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class NotNullAttribute : NullableAttribute
    {
        public NotNullAttribute() : base(false) {}

    }
}
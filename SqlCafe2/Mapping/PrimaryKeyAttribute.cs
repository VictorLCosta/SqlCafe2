using System;

namespace SqlCafe2.Mapping
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class PrimaryKeyAttribute : Attribute
    {
        public PrimaryKeyAttribute()
        {
            Order = -1;
        }

        public PrimaryKeyAttribute(int order)
		{
			Order = order;
		}

        public int Order { get; set; }
    }
}
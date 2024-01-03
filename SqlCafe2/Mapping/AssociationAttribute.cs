using System;

namespace SqlCafe2.Mapping
{   
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AssociationAttribute : Attribute
    {
        public AssociationAttribute() { }

        public string ThisKey { get; set; }

        public string OtherKey { get; set; }
    }
}
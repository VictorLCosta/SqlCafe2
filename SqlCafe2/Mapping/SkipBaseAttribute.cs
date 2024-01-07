using System;

namespace SqlCafe2.Mapping
{
    [Flags]
    public enum SkipModification
    {
        None = 0x0,
        Insert = 0x1,
        Update = 0x2
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public abstract class SkipBaseAttribute : Attribute
    {
        public abstract SkipModification Affects { get; }
    }
}
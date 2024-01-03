using System;

namespace SqlCafe2.Mapping
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
    public class TableAttribute : Attribute
    {
        public TableAttribute()
        {
            IsColumnAttributeRequired = true;
        }

        public TableAttribute(string name)
            : base()
        {
            Name = name;
        }

        public string Name { get; set; }

        public string Schema { get; set; }

        public string Database { get; set; }

        public string Server { get; set; }

        public bool IsColumnAttributeRequired { get; set; }

        /// <summary>
        /// Não utilizado para mapeamento, pode ser usado para fins informativos.
        /// </summary>
        public bool IsView { get; set; }
    }
}
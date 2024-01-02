using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlCafe2.Mapping
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
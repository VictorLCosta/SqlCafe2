using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlCafe2.Sql
{
    public interface ISqlBuilder
    {
        string ParameterPrefix { get; }
    }
}
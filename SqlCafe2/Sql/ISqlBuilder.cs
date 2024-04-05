using System.Text;

namespace SqlCafe2.Sql
{
    public interface ISqlBuilder
    {
        string ParameterPrefix { get; }
        StringBuilder StringBuilder { get; }
    }
}
using System.Linq;

namespace SqlCafe2
{
    public interface ITable<out T> : IQueryable<T>
    {
        
    }
}
#if !NATIVE_ASYNC
using System.Threading.Tasks;

namespace SqlCafe2.Async
{
    public interface IAsyncDisposable
    {
        Task DisposeAsync();
    }
}
#endif
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SqlCafe2.Async
{
    [Flags]
    public enum AsyncLazyFlags
    {
        None = 0x0,
        ExecuteOnCallingThread = 0x1,
        RetryOnFailure = 0x2
    }

    [DebuggerDisplay("Id = {Id}, State = {GetStateForDebugger}")]
    public sealed class AsyncLazy<T>
    {
        private readonly object _mutex;

        private readonly Func<Task<T>> _factory;

        private Lazy<Task<T>> _instance;

        public AsyncLazy(Func<Task<T>> factory, AsyncLazyFlags flags = AsyncLazyFlags.None) 
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));

            if ((flags & AsyncLazyFlags.RetryOnFailure) == AsyncLazyFlags.RetryOnFailure)
                _factory = RetryOnFailure(_factory);
            if ((flags & AsyncLazyFlags.ExecuteOnCallingThread) != AsyncLazyFlags.ExecuteOnCallingThread)
                _factory = RunOnThreadPool(_factory);

            _mutex = new object();
            _instance = new Lazy<Task<T>>(_factory);
        }

        public bool IsStarted
        {
            get
            {
                lock (_mutex)
                    return _instance.IsValueCreated;
            }
        }


        public Task<T> Task
        {
            get
            {
                lock (_mutex)
                    return _instance.Value;
            }
        }

        private Func<Task<T>> RetryOnFailure(Func<Task<T>> factory)
        {
            return async () => 
            {
                try
                {
                    return await factory().ConfigureAwait(false);
                }
                catch (Exception)
                {
                    lock (_mutex)
                    {
                        _instance = new Lazy<Task<T>>(_factory);
                    }
                    throw;
                }
            };
        }

        private static Func<Task<T>> RunOnThreadPool(Func<Task<T>> factory)
        {
            return () => System.Threading.Tasks.Task.Run(factory);
        }

        internal enum LazyState
        {
            NotStarted,
            Executing,
            Completed
        }
    }
}
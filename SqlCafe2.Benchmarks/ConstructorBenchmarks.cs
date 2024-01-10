using BenchmarkDotNet.Attributes;
using Fasterflect;
using FastMember;

namespace SqlCafe2.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn]
    public class ConstructorBenchmarks
    {
        private TypeAccessor acessor =>
            TypeAccessor.Create(typeof(Usuario));

        [Benchmark]
        public object ActivatorCreateInstance() => Activator.CreateInstance<Usuario>();

        [Benchmark]
        public object FastMemberCreateInstance() => acessor.CreateNew();

        [Benchmark]
        public object FastflectConstructor() => typeof(Usuario).CreateInstance();
    }
}
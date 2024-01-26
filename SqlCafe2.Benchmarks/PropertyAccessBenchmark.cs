using System.Linq.Expressions;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using ImmediateReflection;

namespace SqlCafe2.Benchmarks
{   
    [MemoryDiagnoser]
    [RankColumn]
    public class PropertyAccessBenchmark
    {
        private Usuario _usuario =>
            new(Guid.NewGuid(), "Aleatório", 22);


        private ImmediateType type =>
            TypeAccessor.Get<Usuario>();

        [Benchmark(Baseline = true)]
        public object GetProperyValue() => _usuario.GetType().GetProperty("Nome")?.GetValue(_usuario, null)!;

        [Benchmark]
        public object GetImmediatePropertyValue() => type.Properties["Nome"].GetValue(_usuario);

        [Benchmark]
        public object GetImmediatePropertyValue2() => type.Properties["Nome"].GetValue(_usuario);

    }
}
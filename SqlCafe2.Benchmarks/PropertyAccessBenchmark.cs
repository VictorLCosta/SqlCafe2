using BenchmarkDotNet.Attributes;
using FastMember;

namespace SqlCafe2.Benchmarks
{   
    [MemoryDiagnoser]
    [RankColumn]
    public class PropertyAccessBenchmark
    {
        private Usuario _usuario =>
            new("Aleatório", 22, new { Carro = "McLaren" });

        private ObjectAccessor _accessor =>
            ObjectAccessor.Create(_usuario);

        [Benchmark(Baseline = true)]
        public object GetProperyValue() => _usuario.GetType().GetProperty("Nome")?.GetValue(_usuario, null)!;

        [Benchmark]
        public object GetPropertyValue2() => _accessor["Nome"];
    }
}
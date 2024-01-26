using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using FastMember;

namespace SqlCafe2.Benchmarks
{
    internal class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Usuario()
        {
            Nome = "";
            Idade = 0;
        }

        public Usuario(Guid id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Idade: {Idade}";
        }
    }

    [MemoryDiagnoser]
    [RankColumn]
    public class ReflectionBenchmarks
    {
        private TypeAccessor acessor =>
            TypeAccessor.Create(typeof(Usuario));

        [Benchmark]
        public MemberInfo[] GetMembersList() => typeof(Usuario)
            .GetMembers(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.MemberType == MemberTypes.Field && x.MemberType == MemberTypes.Property)
            .ToArray();
        
        [Benchmark]
        public MemberInfo[] GetMemberList2() => typeof(Usuario)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Cast<MemberInfo>()
            .Concat(typeof(Usuario).GetFields(BindingFlags.Public | BindingFlags.Instance))
            .ToArray();

        [Benchmark]
        public MemberSet GetMemberInfoFastMember() => acessor.GetMembers();
    }
}
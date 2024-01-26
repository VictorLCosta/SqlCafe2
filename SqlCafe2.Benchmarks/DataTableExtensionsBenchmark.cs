using System.ComponentModel;
using System.Data;
using BenchmarkDotNet.Attributes;
using Bogus;
using ImmediateReflection;

namespace SqlCafe2.Benchmarks
{
    internal static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item)!;
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static DataTable ToDataTableImmediate<T>(IList<T> data)
        {
            ImmediateProperties props = TypeAccessor.Get<T>().Properties;

            DataTable table = new();
            foreach(ImmediateProperty prop in props)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            foreach(T item in data)
            {
                DataRow row = table.NewRow();
                foreach (ImmediateProperty prop in props)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }

    [MemoryDiagnoser]
    [RankColumn]
    public class DataTableExtensionsBenchmark
    {
        private static List<Usuario> testList => new Faker<Usuario>()
            .RuleFor(x => x.Id, f => Guid.NewGuid())
            .RuleFor(x => x.Idade, f => f.Random.Int(18, 100))
            .RuleFor(x => x.Nome, f => f.Name.FullName())
            .Generate(50);

        [Benchmark(Baseline = true)]
        public DataTable GenerateDataTable() => DataTableExtensions.ToDataTable(testList);
        
        [Benchmark]
        public DataTable GenerateDataTableImmediate() => DataTableExtensions.ToDataTableImmediate(testList);
    }
}
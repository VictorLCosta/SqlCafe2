using SqlCafe2;

namespace SqlCafe.Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (CafeContext context = new CafeContext())
            {
                var a = context.GetDataTable("SELECT * FROM [dbo].[Authors] WHERE Country = @Country", new { Country = "Vietnam" });

                var b = a;
            }
        }
    }
}

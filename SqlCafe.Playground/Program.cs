using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlCafe2;

namespace SqlCafe.Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (CafeContext context = new CafeContext())
            {
                var a = 1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public abstract class Calcu
    {
        public abstract int Add(int a, int b);
    }

    public class add : Calcu
    {
        public override int Add(int a, int b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calcu c1 = new add();
            int res = c1.Add(5, 3);
            Console.WriteLine($"addition is{res}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // numeric data types and their values
            Console.WriteLine(byte.MaxValue);
            Console.WriteLine(byte.MinValue);
            Console.WriteLine(short.MinValue);
            Console.WriteLine(short.MaxValue);
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);
            Console.WriteLine(long.MaxValue);
            Console.WriteLine(long.MinValue);
            Console.WriteLine(float.MinValue);
            Console.WriteLine(float.MaxValue);

            //String 
            string ch = ("new \"string\"");
            Console.WriteLine(ch);

            char[] sai = { 'p', 'a', 'v', 'a', 'n' };
            Console.WriteLine(sai);

        }
    }
}

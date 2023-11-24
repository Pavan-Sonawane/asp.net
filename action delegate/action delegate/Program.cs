using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace action_delegate
{
    class Program
    {
        static void Main()
        {
            Action<string> greetdel = name;
            greetdel("Mayur");

            Action<int, int> adddel = Add;
            adddel(10, 20);

            Action<int, int> muldel = mul;
            muldel(5,8);
            Console.WriteLine();
        }
        static void name(string name)
        {
            Console.WriteLine($"Hello { name } Welcome in Triveni");
        }
        static void Add(int a, int b)
        {
            int sum = a + b;
            Console.WriteLine($"Addition is {sum}");
        }
        static void mul(int a, int b)
        {
            int Mul=a*b;
            Console.WriteLine($"Multiplacation is {Mul}");
        }
    }
}

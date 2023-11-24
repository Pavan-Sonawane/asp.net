using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_compile_time
{
    class Program
    {
        public void add( int x, int y)
        {
            int res = x + y;
            Console.WriteLine($"result is {res}");
        }
        public void add(string a)
        {
            Console.WriteLine($"You have enterd {a}");
        }
    }
    class program1
    {
        static void Main(string[] args)
        {
            Program p1= new Program();
            p1.add(5,6);
            p1.add("pankaj");
        }
    }
}

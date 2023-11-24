using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obsolete
{
     class Program
    {
        [Obsolete("Use method SaySomething1",true)]
        public void s1s() 
        {
            Console.WriteLine("method 1"); 
        }
        public void ss11() 
        {
            Console.WriteLine("method 2"); 
        }

    }
    class program1
    {
        static void Main(string[] args)
        {
            Program p1 = new Program();
            p1.ss11();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace all_loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            for(int i = 0; i <= 10; i++) 
            {
                int num1 = i;
                while(num1%2== 0) 
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace looping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // For loop 
            /* for (int i = 1; i <= 5; i++)
             {

                 Console.WriteLine("*");
             }

             //infinite  for loop 
             for (; ; )
             {
                 Console.WriteLine("this is infinite for loop");
             }
             // while loop
             int i = 0;
             while (i <= 10)
             {
                 Console.WriteLine("this is while loop");
                 i++;
             }

            //dp while loop
            int i = 1;

            do
            {
                Console.WriteLine("this is do while loop");
                i++;
            } while (i <= 10);
            */

            // nested do while loop
            int i = 0;
            do
            {
                int j = 0;
                do
                {
                    Console.Write("({0},{1}) ", i, j);
                    j++;
                } while (j < 2);
                i++;
                Console.WriteLine();

            } while (i < 2);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace task0507
{
     class Program
    {   // call by value 
        static void val(string j)
        {
            j = "this is call by value";

            Console.WriteLine(j);
        }
        //call by refrence
        static void cbr(int n)
        {
            n = 2266;
        }
        static void Main(string[] args)
        {
            // implicit type of variable
            
            var a = ("this is implicit type of variable");
            Console.WriteLine(a);
            Console.WriteLine(a.GetType());

            //explicitly typed variable
            int i = 123;
            int j = 223;
            int c = i + j;
            Console.WriteLine("it is explicit type of variable",c);
            Console.WriteLine(c.GetType());

            //nullable type
            int? k = 10;
            
            if (k.HasValue)
            {
                Console.WriteLine($"is contains value{k}");
            }
            else
            {
                Console.WriteLine($"it does not contains the value{k}");
            }
            //Anonymous Type
            var ann = new { id = 1,firstname="ram", lastname="doe",height=9.85M, a=12345F,b=1.832D,e= 92233720368547753l };
            Console.WriteLine(ann.id);
            Console.WriteLine(ann.firstname);
            Console.WriteLine(ann.lastname);
            Console.WriteLine(ann.height);
            Console.WriteLine(ann.a);
            Console.WriteLine(ann.b);
            Console.WriteLine(ann.e);
            Console.WriteLine(ann.GetType().ToString());
            
            // call by value 
            string Z = "this is call by value 2";

            Console.WriteLine(Z);

            val(Z);

            Console.WriteLine(Z);

            //call by refrence

           
            int n =2255;

            cbr(n);

            Console.WriteLine(n);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function1
{
    internal class Program
    {
        class func
        {
            
            public void Show()  
            {
                Console.WriteLine("this is a non parametrized function");
                 
            }
             
            static void Main(string[] args)
            {
               func program = new func();   
                program.Show();            
            }
        }
    }
}

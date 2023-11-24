#define start1
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conditional
{
    class condi
    {
        [Conditional("start1")]
        void Start()
        {
            Console.WriteLine("Car is Starting");
        }

        [Conditional("stop1")]
        void Stop()
        {
            Console.WriteLine("Car has been stopped");
        }
        class Program
        {
            static void Main(string[] args)
            {
                condi cd=new condi();   
                cd.Start();
                cd.Stop();
            }
        }
    }
}


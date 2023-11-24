using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorph_runtime
{
    class run
    {
        public  virtual void vehicle(int x, int y)
        {
            Console.WriteLine($"vehicle is running{x + y}");
        }

    }
    class stop : run
    {
        public  override void vehicle(int x, int y)
        {
            Console.WriteLine($"vehicle is stop {y - x}");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
           
            stop s1 = new stop();
            run r1 = new run();
            run r2 = new stop();

            s1.vehicle(5, 5);
            r1.vehicle(5, 8);
            r2.vehicle(10, 8);
        }
    }
}

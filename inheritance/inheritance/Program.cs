using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    class Vehicle
    {
        public void drive()
        {
            Console.WriteLine("Pratik Driving the car");
        }
    }

   
    class Car : Vehicle
    {
        public void stop()
        {
            Console.WriteLine("pankaj stopping the car");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car Car = new Car();
            Car.drive();

            Car.stop();
            Console.ReadLine();
        }
    }

}

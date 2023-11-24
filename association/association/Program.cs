using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace association
{
    class Vehicle
    {
        public string Model { get; set; }
    }

    class Car : Vehicle
    {
        public void Drive()
        {
            Console.WriteLine("Pavan driving the car.");
        }
    }

    class Bike : Vehicle
    {
        public void Ride()
        {
            Console.WriteLine(" pavan riding the bike.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Model = "hatchback";

            Bike bike = new Bike();
            bike.Model = "adventure bike";

            Console.WriteLine("car Model: " + car.Model);
            car.Drive();

            Console.WriteLine("bike Model: " + bike.Model);
            bike.Ride();
        }
    }
}

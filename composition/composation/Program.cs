using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EDUCBA
{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("Engine started.");
        }

        public void Stop()
        {
            Console.WriteLine("Engine stopped.");
        }
    }

    
    public class Car
    {
        private Engine engine;

        public Car()
        {
            engine = new Engine();
        }

        public void StartCar()
        {
            engine.Start();
        }

        public void StopCar()
        {
            engine.Stop();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.StartCar();
            car.StopCar();
        }
    }
}

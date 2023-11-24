using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remta
{
    using System;

    public interface ICalc
    {
        void Sum(int a, int b);
        void Exponential(int baseNumber, int power);
        void ter(int p);
    }

    public class Calculator : ICalc
    {
        public void Sum(int a, int b)
        {
            int result = a + b;
            Console.WriteLine("Sum: " + result);
        }

        public void Exponential(int baseNumber, int power)
        {
            int result = (int)Math.Pow(baseNumber, power);
            Console.WriteLine("Exponential: " + result);
        }

        public void ter(int p)
        {
            var inc=p<0?"negative": "positive";
            Console.WriteLine(inc);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.Sum(5, 3);
            calculator.Exponential(5, 4);
            calculator.ter(-10);
        }
    }



}

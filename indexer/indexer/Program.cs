using System;

namespace indexer
{
    public interface ICalculator
    {
        void Sum(int a, int b);
        void Exponential(int baseNumber, int power);
        void PrintAppoint();
    }

    public class Calculator : ICalculator
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

        public void PrintAppoint()
        {
            Console.WriteLine("Appoint meBay!");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.Sum(5, 3);
            calculator.Exponential(7, 4);
            calculator.PrintAppoint();
        }



    }

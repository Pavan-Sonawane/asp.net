using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


delegate double SquareRoot(double num);

class Program
{
    static double SquareRoot(double num)
    {
        return num * num;
    }

    static void Main(string[] args)
    {
         Console.Write("Enter a number: ");
        double number = Convert.ToDouble(Console.ReadLine());
        SquareRoot square = new SquareRoot(SquareRoot);
        double result = square(number);
        Console.WriteLine("Square root: " + result);
    }
}


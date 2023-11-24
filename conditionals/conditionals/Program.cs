using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conditionals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //condatinals
            //1) if else
            //Write a C# Sharp program to accept two integers and check whether they are equal or not.
            Console.WriteLine("enter the number 1 ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the number 2");
            int num2 = Convert.ToInt32(Console.ReadLine());

            if (num1 == num2)
            {
                Console.WriteLine($"{num1}and {num2} are same");
            }
            else
            {
                Console.WriteLine($"{num1} and {num2} is not same");

            }
            //Write a C# Sharp program to check whether a given number is even or odd.
            Console.WriteLine("enter the number for checking the even or odd");
            int num3 = Convert.ToInt32(Console.ReadLine());
            if (num3 % 2 == 0)
            {
                Console.WriteLine($"{num3} is even number");
            }
            else
            {
                Console.WriteLine($"{num3} is odd number");
            }
            //1) if else if

            Console.WriteLine("enter the age of the candidate");
            int age = Convert.ToInt32(Console.ReadLine());
            if (age <= 18)
            {
                Console.WriteLine($"YOUR AGE IS{age}YOU ARE NOT ELIGIBLE FOR THE VOATING");
            }
            else if (age >= 18)
            {
                Console.WriteLine($"YOUR AGE IS{age}YOU ARE ELIGIBLE FOR THE VOATING");
            }
            else if (age < 0)
            {
                Console.WriteLine($"{age}IS NOT A VALID AGE");
            }
            //3) switch case
            Console.WriteLine("enter the number between 1 to 10");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.WriteLine("you have entered 1");
                    break;

                case 2:
                    Console.WriteLine("you have entered number 2");
                    break;
                case 3:
                    Console.WriteLine("you have entered 3");
                    break;
            }
            Console.WriteLine("enter the state");
            string state = Console.ReadLine();
            switch (state.ToLower())
            {
                case "maharashtra":
                    Console.WriteLine("your state code is 123");
                    break;
                case "rajasthan":
                    Console.WriteLine("you state code is 2266");
                    break;
                case "up":
                    Console.WriteLine("your state code is 4466");
                    break;
            }
            // number comparison app
            int a = 7;
            int b = 76;
            int c = 7;
            if (a < b)
            {
                Console.WriteLine("b is big");
            }
            else if (b < c)
            {
                Console.WriteLine("c is big");
            }
            else if (c < a)
            {
                Console.WriteLine("a is big");
            }
            else
            {
                Console.WriteLine("all are same");
            }

        }
    }
}

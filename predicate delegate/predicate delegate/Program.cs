
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        var numbers = new List<int> { 1, 2, 3, 4, 5 };


        Predicate<int> isEven = Even;

        var evenNumbers = numbers.FindAll(isEven);

        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number);
        }
    }

    static bool Even(int number)
    {
        return number % 2 == 0;
    }
}

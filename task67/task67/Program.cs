using System;

public interface ICalc
{
    void Sum(int a, int b);
    void Expo(int x, int y);
    void msg(int p);
}

public class Calculator : ICalc
{
    public void Sum(int a, int b)
    {
        int result = a + b;
        Console.WriteLine("Sum is" + result);
    }

    public void Expo(int x, int y)
    {
        int result = (int)Math.Pow(x, y);
        Console.WriteLine("Expo is " + result);
    }

    public void msg(int p)
    {
        var ans = p < 0 ?"negative number":"positive number";
        Console.WriteLine("you have entered"+ans);  
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        calculator.Sum(5, 3);
        calculator.Expo(2, 4);
        calculator.msg(10);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class notvalidage : Exception
{
    public notvalidage(string s) : base(s)
    {

    }
}
class ssc1
{
    static void checkage(int i)
    {
        if (i < 18)
        {
            throw new notvalidage("your age us less than 18");
        }
    }
    public static void Main(string[] args)
    {

        Console.WriteLine("enter the number");
        var i = Convert.ToInt32(Console.ReadLine());
        try
        {
            checkage(i);
        }
        catch (notvalidage e)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine("you age is valid");
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Reflection;

class Program
{
    [Simplex]
    public static void SimpleMethod()
    {
        Console.WriteLine("This is a simple method.");
    }

    [Simplex]
    public static void AnotherMethod()
    {
        Console.WriteLine("This is another simple method.");
    }
    public static void anotheron()
    {
        Console.WriteLine("this is another method");
    } 
    

     static void Main()
    {
        Type programType = typeof(Program);
        MethodInfo[] methods = programType.GetMethods();

        foreach (MethodInfo method in methods)
        {
           
            if (method.GetCustomAttribute<SimplexAttribute>() != null)
            {
                Console.WriteLine($"Found a method with SimplexAttribute: {method.Name}");
                method.Invoke(null, null); 
            }
           
           
        }
    }
}

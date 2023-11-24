using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public sealed class Single
{
    private static readonly Lazy<Single> lazy = new Lazy<Single>(() => new Single());
    private Single()
    {
        Console.WriteLine("Singleton instance created.");
    }
    public static Single Instance
    {
        get
        {
            return lazy.Value;
        }
    }
}
class Program
{
    public static void Main()
    {
        Single instance1 = Single.Instance;
        Single instance2 = Single.Instance;
        if (instance1 == instance2)
        {
            Console.WriteLine("Both instances are the same.");
        }
        else
        {
            Console.WriteLine("Instances are different.");
        }
    }
}

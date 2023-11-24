using System;
public class Singleton
{
    private static Singleton instance;
    private Singleton()
    {
    }
    public static Singleton GetInstance()
    {
        if (instance == null)
        {
            instance = new Singleton();
        }
        return instance;
    }
    public void SomeMethod()
    {
        Console.WriteLine("Executing a method in Singleton instance.");
    }
}
class Program
{
    static void Main()
    {
        Singleton singleton1 = Singleton.GetInstance();
        Singleton singleton2 = Singleton.GetInstance();
        Console.WriteLine(singleton1 == singleton2);
        singleton1.SomeMethod();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
public class Animal
{
    public virtual void sound()
    {
        Console.WriteLine("making sound");
    }
    public void sound(int a)
    {
        Console.WriteLine("integer value"+a);
    }
}

public class Dog : Animal
{
    public override void sound()
    {
        Console.WriteLine("barking");
    }

    public void sound(string mes)
    {
        Console.WriteLine("The dog is " + mes);
    }
}

class Program
{
    static void Main()
    {
        Animal animal1 = new Animal();
        Animal animal2 = new Dog();
        Dog dog = new Dog();

        animal1.sound();
        animal2.sound();
        dog.sound("sounding");



        Dictionary<int, string> dict = new Dictionary<int, string>();
        dict.Add(11, "sai ,saisha,tarak");
        dict.Add(22, "sai ram");
        dict.Add(33, "om sai ram");
        dict.Add(55, "pankaj");
        dict.Add(77, "saisha");
        dict.Add(78, "kiran");
        foreach (var item in dict)
        {
            Console.WriteLine(item);
        }
    }
}

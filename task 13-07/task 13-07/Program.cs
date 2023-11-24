

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    
    
}


class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a shape");
    }
    public virtual void Draw1()
    {
        Console.WriteLine("this is hiding");
    }

}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine(" circle");
    }

    public void Draw(string color)
    {
        Console.WriteLine("Drawing a " + color + " circle");
    }
    public new void Draw1(int n)
    {
        Console.WriteLine(n);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape shape = new Shape();
        shape.Draw(); 
        Circle circle = new Circle();
        circle.Draw(); 
        circle.Draw("red");
        circle.Draw1(123);
    }
}

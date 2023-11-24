using System;

namespace task0607
{
    public interface Idraw
    {
        void circle();

    }
    public class shapes : Idraw
    {
        public void circle()
        {
            Console.WriteLine("THIS IS CIRCLE");
        }
    }
    class Allshape
    {
        public static void main(string[] args)
        {
            shapes s = new shapes();
            s.circle();
        }

    }


}

using System;

namespace _2int1c
{
    public interface iking
    {
        void show();
    }

    public interface iqueen
    {
        void hide();
    }
    class state : iking, iqueen
    {
        public void show()
        {
            Console.WriteLine("this is i king");
        }
        public void hide()
        {
            Console.WriteLine("this is queen");

        }
    }
    class country
    {
        public static void Main(string[] args)
        {
            iking i;
            iqueen q;
            i = new state();
            q = new state();
            i.show();
            q.hide();
        }
    }
}
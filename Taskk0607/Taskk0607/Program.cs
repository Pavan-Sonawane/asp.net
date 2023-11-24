using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskk0607
{
    public interface Iprogram
    {
        void debugging();
        void running();
    }
    class java : Iprogram
    {
        public void debugging()
        {
            Console.WriteLine("java program is running ");
        }
        public void running() 
        {
            Console.WriteLine("this i running program");
        }
    }
    class python:java,Iprogram
    {
        public void debugging()
        {
            Console.WriteLine("python program is debugging");
        }
        public void running()
        {
            Console.WriteLine("python code is running");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("this is main class");
            java j = new java(); 
            python p=new python();
            j.debugging();
            j.running();
            p.debugging();
            p.running();

        }
    }
}

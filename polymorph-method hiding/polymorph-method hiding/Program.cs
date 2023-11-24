using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorph_method_hiding
{
    class student
    { 
        public void stud1()
        {
            Console.WriteLine("Parent Class");
        }

    }
    class teacher : student 
    { 
        public new void stud1()
        {
            Console.WriteLine("child class");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            student s1 = new student();
            teacher t1=new teacher();
            student t3 = new teacher();
            s1.stud1();
            t1.stud1();
            t3.stud1();
        }
    }
}

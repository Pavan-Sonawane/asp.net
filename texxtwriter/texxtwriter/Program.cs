using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace texxtwriter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (TextWriter writer = File.CreateText("D:\\textwriter.txt"))
            {
                writer.WriteLine("This is ext writer in CH#");
                writer.WriteLine("welcome in the world of c");
            }
            //Reading the File 
            using (TextReader rr = File.OpenText("D:\\textwriter.txt"))
            {
                Console.WriteLine(rr.ReadToEnd());
            }
          
        }
    }
}

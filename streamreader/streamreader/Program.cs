using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace streamreader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream s = new FileStream("D:\\new1.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(s);
            string line=sr.ReadLine();
            Console.WriteLine(line);
            s.Close();
            sr.Close();
        }
    }
}

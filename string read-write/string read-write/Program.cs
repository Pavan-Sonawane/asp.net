using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_read_write
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //writing the string
            string str = "this is the example of string bulider and and string writer ";
            StringBuilder sb= new StringBuilder();
            StringWriter sr = new StringWriter(sb);
            sr.WriteLine(str);
            sr.Flush();
            sr.Close();
            Console.WriteLine("string has been written successfully");
            //Reading the String
            StringReader stringReader = new StringReader(sb.ToString());
            Console.WriteLine(stringReader.ReadToEnd());
        }
    }
}

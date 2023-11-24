using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filestream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream st = new FileStream("D:\\new.txt", FileMode.OpenOrCreate);
           st.WriteByte((byte)88);
            st.Close();

            StreamReader s=new StreamReader(st);
            string line = s.ReadLine();
            Console.WriteLine(line);
            s.Close();
        }
    }
   
}

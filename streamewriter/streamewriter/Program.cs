
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace streamewriter
{
    class Program1
    {
        static void Main(string[] args)
        {
            FileStream st = new FileStream("D:\\new1.txt", FileMode.OpenOrCreate);
            StreamWriter s = new StreamWriter(st);

            s.WriteLine("this is streamwriter");
            StreamReader ss = new StreamReader(st);
            string line = ss.ReadLine();
            s.Close();
            st.Close();
        }
    }
}

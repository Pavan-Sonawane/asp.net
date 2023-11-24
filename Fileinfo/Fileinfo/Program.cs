
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileinfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //file info 
            string file = "D:\\new3.txt";
            FileInfo f1=new FileInfo(file);
            f1.Create();
            //DirectoryInfo
            string dirs = "D:\\new4.txt";
            DirectoryInfo dir = new DirectoryInfo(dirs);
            dir.Create();
            Console.WriteLine("dirctory has been created successfully");
            //dir.Delete();
            //Console.WriteLine("directory has been deleted successfully");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace binary_read___write
{
    internal class Program
    {
        static void Main(string[] args)

        {
            // write binary 
            string FileName = "D:\\binary.txt";
            using (BinaryWriter bin = new BinaryWriter(File.Open(FileName, FileMode.Create)))
            {
                 bin.Write(11.88);
                 bin.Write("Car is running");
                 bin.Write(true);
                bin.Write(112);
            }
            Console.WriteLine("File Successfullly written");
            // read binary
            using(BinaryReader bin1=new BinaryReader(File.Open("D:\\binary.txt",FileMode.Open)))
            {
                Console.WriteLine("Double Value  " + bin1.ReadDouble());
                Console.WriteLine("String Value  " + bin1.ReadString());
                Console.WriteLine("Boolean Value  " + bin1.ReadBoolean());
                Console.WriteLine("Integer  Value  " + bin1.ReadInt16());
            }

        }
    }
}

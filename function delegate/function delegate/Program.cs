using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class myfun
{


    public static string myfun1(string s, string d, string f, string g)
    {
        return s + d + f + g;
    }



    static public void Main()
    {

        Func<string, string, string, string, string> val = myfun1;
        Console.WriteLine(val("pavan+", "mayur+", "panjak+", "pratik"));
    }
}


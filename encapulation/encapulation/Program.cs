using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    class encap
    {
        private string name = "Pavan Sonawnae";

        public string Getname()
        {
            return name;
        }

        public void Setname(string s)
        {
            name = s;
        }
    }

    class namechange
    {
        static void Main(string[] args)
        {
            encap s = new encap();
            s.Setname("sai");
            Console.WriteLine(s.Getname());
        }
    }
}

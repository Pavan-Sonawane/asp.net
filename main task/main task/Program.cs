using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main_task
{
    class pavan
    {
        private void pavanj()
        {
           
            Console.WriteLine(" am pavanj" );
        }
        public void pankaj()
        {
            Console.WriteLine("this is pankaj");
            pavanj();

        }
        protected void mayur()
        {
            Console.WriteLine("am mayur");
        }
        public void pratik()
        {
            Console.WriteLine("am pratik");
            
        }

    }
    class system: pavan
    {
        public static void Main(string[] args)
        {
            pavan p = new pavan();
            p.pankaj();
            p.pratik();
            system  dd = new system ();
            dd.mayur();

        }
    }
}

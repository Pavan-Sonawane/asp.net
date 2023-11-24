using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class em
    {
        public int id {get;set;}    
        public string name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            em[] employee =
            {
                new em(){ id=1,name="pavan", country="india",city="surat"},
                new em() { id=2,name = "sahil", country = "india", city = "surat" }, 
                new em(){id=3,name= "Pratik", country="USA",city="CA" },
                new em(){id=4, name= "Pankaj", country="Londan",city="paris"},
                new em(){ id=5,name= "Mayur", country="india",city="Maharashtra"}
               
            };
            List<int> ints = new List<int>()
            { 1,2,3,4,5,6,7,8,9,10};
            bool j=ints.Contains(1);
            //where using normal method
            var detail1 = from con in employee 
                          where con.id<4
                          select con;

            //using lambda function
            var details = employee.Where(s => s.id < 3);

            //using normal method
            var n=from i in employee
                       orderby i.id descending
                       select i;
            //order by using lambda
            var nn = employee.OrderBy (s => s.name).ThenByDescending(s => s.city).ThenByDescending(s=>s.country);
            // group by clause
           

            


            Console.WriteLine("**************where clause normal*****************");
            foreach (var item in detail1)
            {
                Console.WriteLine(item.city);
            }
            Console.WriteLine("**************where clause using lambda*****************");
            foreach (var item in details)
            {
                Console.WriteLine(item.name);
            }
            Console.WriteLine("**************Order by clause****************");
            foreach (var item in n)
            {
                Console.WriteLine(item.id);
            }
            Console.WriteLine("*********Order by clause using lambda function****************");
            foreach (var item in nn)
            {
                Console.WriteLine($"ordered {item.name} , {item.city} , {item.country}");
            }
          
            

        }
    }
}

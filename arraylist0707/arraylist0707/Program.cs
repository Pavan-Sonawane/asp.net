using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace arraylist0707
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------Array list---------------------");
            var ArrL = new ArrayList();
                ArrL.Add(1);
            ArrL.Add(2);   //Adding the element
            ArrL.Add(3);
            ArrL.Add(4);
            ArrL.Add(5);
            ArrL.Add(6);
            ArrL.Add(null);
            ArrL.Add("pavan");
            Console.WriteLine("array list contains  "+ArrL.Count +"elements"); //counting element from arraylist   
            foreach(var item in ArrL)
            {
                Console.WriteLine(item);
            }
            ArrL.Remove("pavan");//Removing Element from the arraylist
            foreach (var item in ArrL)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("this is list");
            Console.WriteLine("-----------------List---------------------");
            List<int> lst = new List<int>();
            lst.Add(11);
            lst.Add(22);
            lst.Add(33);
            lst.Add(44);
            lst.Add(55);
            lst.Add(66);
            
            Console.WriteLine("this list contains" + lst.Count);
            lst.RemoveAt(2);            // removing element
            Console.WriteLine( lst.Contains(5)); //checking element present or not
            Console.WriteLine(lst.Contains(55));
            foreach (var item in lst)
                Console.WriteLine(item);

            Console.WriteLine("----------------- sorted list--------------------");
            {
                SortedList<string, string> names = new SortedList<string, string>();
                names.Add("1", "mayur");
                names.Add("4", "Pavan");
                names.Add("5", "pankaj");
                names.Add("3", "pratik");
                names.Add("2", "sahil");
                names.Remove("1");
                names.RemoveAt(2);
                foreach (KeyValuePair<string, string> name1 in names)
                {
                    Console.WriteLine(name1.Key + " " +name1.Value);
                }
                Console.WriteLine("this sorted list contains"+names.Count);
            }
            Console.WriteLine("----------------- Dictionary--------------------");

            Dictionary<int,string> dict = new Dictionary<int,string>();
            dict.Add(11, "sai ,saisha,tarak");
            dict.Add(22, "sai ram");
            dict.Add(33, "om sai ram");
            dict.Add(55, "pankaj");
            dict.Add(77, "saisha");
            dict.Add(78, "kiran");
            dict.Remove(12);
            dict[11] =("RUPESH,SHIL");
            Console.WriteLine(dict.ElementAt(5));
            Console.WriteLine(dict.Count);
            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------- Hashtable--------------------");

            var ht =new Hashtable()
            {
                { "Books","c#,python,c,java"},
                {12,"google,facebok,instagram,google maps" }
            };
            ht["books"] = "hadoop";
            Console.WriteLine( ht.Contains("books"));
            ht.Remove(12);
            ht.Clear();
            foreach(DictionaryEntry  item in ht)
            {
                Console.WriteLine(" "+item.Key,item.Value);
            }
                       Console.WriteLine("----------------- Stack--------------------");

           Stack<string> stk=new Stack<string>();
            stk.Push("one");
            stk.Push("two");
            stk.Push("three");
            stk.Push("four");
            stk.Push("five");
            stk.Push("six");
            Console.WriteLine("count"+stk.Count);
            Console.WriteLine($"{stk.Pop()} this element has been popped ");
            Console.WriteLine("last return element is   " + stk.Peek());
            foreach (string item in stk)
            {
                Console.WriteLine( item);
            }
            Console.WriteLine("----------------- Queue--------------------");

            Queue<long> numbers=new Queue<long>();
            numbers.Enqueue(7507082982);
            numbers.Enqueue(8263080612);
            numbers.Enqueue(7498962190);
            numbers.Enqueue(8952637874);
            numbers.Dequeue();
            Console.WriteLine($"{+numbers.Count}  are present");
            Console.WriteLine($"{+numbers.Peek()} this is peek element");
            foreach (var  item in numbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------Tuple--------------------");

            Tuple<int, string, long> Emp = new Tuple<int, string, long>(1, "pavan", 7507082982);
            Console.WriteLine("employee Id "+Emp.Item1);
            Console.WriteLine("employee name "+ Emp.Item2);
            Console.WriteLine("employee mobile number "+Emp.Item3);
            Console.WriteLine(Emp);
            //static method
            var num = Tuple.Create(2, "mayur", 8236080612);
            Console.WriteLine(num.Item1);



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[] {
                new Person(){ID=1, Name= "avi" },
                new Person(){ID=3, Name= "benny" },
                new Person(){ID=4, Name= "dora" },
                new Person(){ID=2, Name= "charlie" },
            };

            Print(persons);
            Array.Sort(persons);
            Console.WriteLine(  );
            Print(persons);

            IComparable ic = new Person();
            //ic.

            //Sort(imcpoarble[] objecs){ 
            
            //}
        }



        private static void Print(Person[] persons)
        {
            foreach (var item in persons)
            {
                Console.WriteLine( item );
            }
        }
    }

    class Person : IComparable
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            //return ID.CompareTo(((Person)obj).ID);
            return Name.CompareTo(((Person)obj).Name);
            //if (ID < ((Person)obj).ID)
            //{
            //    return 1;
            //}
            //else if (((Person)obj).ID < ID)
            //{
            //    return -1;
            //}
            //else { return 0; }
        }

        public override string ToString()
        {
            return $"{ID}, {Name}";
        }
    }
}

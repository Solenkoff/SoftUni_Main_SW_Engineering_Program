using System;
using System.Text;

namespace CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {

            IAddable addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split();

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();

            foreach (var item in input)
            {              
                sb1.Append(addCollection.Add(item) + " ");
                sb2.Append(addRemoveCollection.Add(item) + " ");
                sb3.Append(myList.Add(item) + " ");
            }

            int nRemoveOperations = int.Parse(Console.ReadLine());

            StringBuilder sb4 = new StringBuilder();
            StringBuilder sb5 = new StringBuilder();

            for (int i = 0; i < nRemoveOperations; i++)
            {
                sb4.Append(addRemoveCollection.Remove() + " ");
                sb5.Append(myList.Remove() + " ");
            }

            Console.WriteLine(sb1.ToString().TrimEnd());
            Console.WriteLine(sb2.ToString().TrimEnd());
            Console.WriteLine(sb3.ToString().TrimEnd());
            Console.WriteLine(sb4.ToString().TrimEnd());
            Console.WriteLine(sb5.ToString().TrimEnd());
        }
    }
}

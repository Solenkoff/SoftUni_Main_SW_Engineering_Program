using System;
using System.Collections.Generic;

namespace _05v2_Generic_Count_Method_String
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Box<string>> boxes = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<string> currBox = new Box<string>(Console.ReadLine());
                boxes.Add(currBox);
            }


            string value = Console.ReadLine();
            Box<string> boxToCompareTo = new Box<string>(value);

            int count = GetCountOfGreaterElements(boxes, boxToCompareTo);

            Console.WriteLine(count);

        }


        private static int GetCountOfGreaterElements<T>(List<Box<T>> boxes, Box<T> comparator)
           where T : IComparable
        {
            int count = 0;
            foreach (Box<T> box in boxes)
            {
                if (box.CompareTo(comparator) > 0)
                {
                    count++;
                }

            }

            return count;
        }
    }
}

using System;
using System.Collections.Generic;

namespace _06_Generic_Count_Method_Double
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Box<double>> boxes = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<double> currBox = new Box<double>(double.Parse(Console.ReadLine()));
                boxes.Add(currBox);
            }


            double value = double.Parse(Console.ReadLine());
            Box<double> boxToCompareTo = new Box<double>(value);

            int count = GetCountOfGreaterElements(boxes, boxToCompareTo);

            Console.WriteLine(count);

        }


        private static int GetCountOfGreaterElements<T>(List<Box<T>> boxes, Box<T> comparator)
          where T : IComparable
        {
            int count = 0;
            foreach (Box<T> box in boxes)
            {
                if (box.Value.CompareTo(comparator.Value) > 0)
                {
                    count++;
                }

            }

            return count;
        }

    }
}

using System;
using System.Collections.Generic;

namespace _04_Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            HashSet<int> nums = new HashSet<int>();
            HashSet<int> numsEvenOccurrences = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (nums.Contains(num))
                {

                    if(numsEvenOccurrences.Contains(num))
                    {
                        numsEvenOccurrences.Remove(num);
                    }
                    else
                    {
                        numsEvenOccurrences.Add(num);
                    }

                }
                else
                {
                    nums.Add(num);
                }

            }

            foreach (var item in numsEvenOccurrences)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}

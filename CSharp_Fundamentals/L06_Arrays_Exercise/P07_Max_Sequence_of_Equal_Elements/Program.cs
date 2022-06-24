using System;
using System.Linq;

namespace _07_Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine()
                              .Split()
                              .Select(int.Parse)
                              .ToArray();

            int maxCounter = 0;
            int maxSequenceNum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int counter = 1;
                int currentNum = 0;

                for (int j = i + 1; j < arr.Length; j++)
                {

                    if (arr[i] != arr[j])
                    {
                        break;
                    }
                    else if (arr[i] == arr[j])
                    {
                        currentNum = arr[i];
                        counter++;
                    }

                }
                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    maxSequenceNum = currentNum;
                }
            }
            int[] maxSequence = new int[maxCounter];
            for (int i = 0; i < maxCounter; i++)
            {
                maxSequence[i] = maxSequenceNum;
            }
            Console.WriteLine(string.Join(" ", maxSequence));

        }
    }
}

using System;

using System.Linq;

namespace _09_Kamino_Factory_
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLenght = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] newArray = new int[sequenceLenght];
            int counter = 0;
            int highestSum = 0;
            while (input != "Clone them!")
            {

                int[] arr = input.Split("!", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
                int sum = arr.Sum();
                int startIndex = 0;

                for (int i = 0; i < sequenceLenght; i++)
                {
                    int currentSum = 1;
                    int currStartIndex = 0;
                    for (int j = i + 1; j < sequenceLenght; j++)
                    {
                        if (arr[i] == 1 && arr[j] == 1)
                        {
                            currentSum++;
                            currStartIndex = i;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (currentCounter > counter)
                    {
                        counter = currentCounter;
                    }
                    if (currentCounter == counter)
                    {
                        if (s)

                    }
                }


                input = Console.ReadLine();
            }
        }
    }
}

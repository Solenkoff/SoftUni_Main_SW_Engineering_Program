using System;

namespace _03_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int validCombinationCount = 0;

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int k = 0; k <= n; k++)
                    {
                        if (i + j + k == n)
                        {
                            validCombinationCount++;
                        }
                    }
                }
            }
            Console.WriteLine(validCombinationCount);
        }
    }
}

using System;
using System.Linq;

namespace _02_Garden
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] dimensions = Console.ReadLine()
                                      .Split(" ")
                                      .Select(int.Parse)
                                      .ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            int[,] garden = new int[n, m];

            string input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                int[] rowColData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                int row = rowColData[0];
                int col = rowColData[1];

                if (row < 0 || row > n - 1 || col < 0 || col > m - 1)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    for (int i = 0; i < m; i++)
                    {
                        garden[row, i]++;
                    }
                    for (int j = 0; j < n; j++)
                    {
                        garden[j, col]++;
                    }

                    garden[row, col]--;
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

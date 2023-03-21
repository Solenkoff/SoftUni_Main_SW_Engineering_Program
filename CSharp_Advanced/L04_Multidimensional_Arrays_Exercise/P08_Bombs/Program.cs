using System;
using System.Linq;

namespace _08_Bombs_
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int[,] field = new int[n, n];

            FillUpField(field);

            string[] bombData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            BombDamage(field, bombData);

            int elementsAlive = 0;
            int elementsAliveSum = 0;

            foreach (int cell in field)
            {
                if (cell > 0)
                {
                    elementsAlive++;
                    elementsAliveSum += cell;
                }
            }
            Console.WriteLine($"Alive cells: {elementsAlive}");
            Console.WriteLine($"Sum: {elementsAliveSum}");
            PrintField(field);
        }


        private static void PrintField(int[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");

                }
                Console.WriteLine();
            }
        }

        private static void BombDamage(int[,] field, string[] bombData)
        {
            foreach (string data in bombData)
            {
                int[] currBombData = data.Split(",", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();
                int currBombRow = currBombData[0];
                int currBombCol = currBombData[1];
                int currBomb = field[currBombRow, currBombCol];


                for (int row = currBombRow - 1; row <= currBombRow + 1; row++)
                {
                    for (int col = currBombCol - 1; col <= currBombCol + 1; col++)
                    {
                        if (row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1))
                        {
                            if (field[row, col] <= 0 || currBomb < 0)
                            {
                                continue;
                            }
                            field[row, col] -= currBomb;
                        }

                    }

                }

            }
        }

        private static void FillUpField(int[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];
                }
            }
        }
    }
}

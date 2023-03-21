using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_Radioactive_Mutant_Vampire_Bunnies_
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rowColData = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();
            int rows = rowColData[0];
            int cols = rowColData[1];

            char[,] lair = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    lair[row, col] = rowData[col];
                }
            }

            char[] diractions = Console.ReadLine().ToCharArray();

            int playersCurrRow = -1;
            int playersCurrCol = -1;

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'P')
                    {
                        playersCurrRow = row;
                        playersCurrCol = col;
                        lair[playersCurrRow, playersCurrCol] = '.';
                    }
                }
            }

            for (int i = 0; i < diractions.Length; i++)
            {
                char direction = diractions[i];

                if (direction == 'L')
                {
                    if (IsInsideTheLaid(lair, playersCurrRow, playersCurrCol - 1))
                    {
                        playersCurrCol--;
                        lair = BunniesSpread(lair);
                        if (lair[playersCurrRow, playersCurrCol] == 'B')
                        {
                            PrintLair(lair);
                            Console.WriteLine($"dead: {playersCurrRow} {playersCurrCol}");
                            return;
                        }
                    }
                    else
                    {
                        lair = BunniesSpread(lair);
                        PrintLair(lair);
                        Console.WriteLine($"won: {playersCurrRow} {playersCurrCol}");
                        return;
                    }
                }
                else if (direction == 'R')
                {
                    if (IsInsideTheLaid(lair, playersCurrRow, playersCurrCol + 1))
                    {
                        playersCurrCol++;
                        lair = BunniesSpread(lair);
                        if (lair[playersCurrRow, playersCurrCol] == 'B')
                        {
                            PrintLair(lair);
                            Console.WriteLine($"dead: {playersCurrRow} {playersCurrCol}");
                            return;
                        }
                    }
                    else
                    {
                        lair = BunniesSpread(lair);
                        PrintLair(lair);
                        Console.WriteLine($"won: {playersCurrRow} {playersCurrCol}");
                        return;
                    }
                }
                else if (direction == 'U')
                {
                    if (IsInsideTheLaid(lair, playersCurrRow - 1, playersCurrCol))
                    {
                        playersCurrRow--;
                        lair = BunniesSpread(lair);
                        if (lair[playersCurrRow, playersCurrCol] == 'B')
                        {
                            PrintLair(lair);
                            Console.WriteLine($"dead: {playersCurrRow} {playersCurrCol}");
                            return;
                        }
                    }
                    else
                    {
                        lair = BunniesSpread(lair);
                        PrintLair(lair);
                        Console.WriteLine($"won: {playersCurrRow} {playersCurrCol}");
                        return;
                    }
                }
                else if (direction == 'D')
                {
                    if (IsInsideTheLaid(lair, playersCurrRow + 1, playersCurrCol))
                    {
                        playersCurrRow++;
                        lair = BunniesSpread(lair);
                        if (lair[playersCurrRow, playersCurrCol] == 'B')
                        {
                            PrintLair(lair);
                            Console.WriteLine($"dead: {playersCurrRow} {playersCurrCol}");
                            return;
                        }
                    }
                    else
                    {
                        lair = BunniesSpread(lair);
                        PrintLair(lair);
                        Console.WriteLine($"won: {playersCurrRow} {playersCurrCol}");
                        return;
                    }
                }
            }

        }


        private static void PrintLair(char[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }
        }


        private static char[,] BunniesSpread(char[,] lair)
        {
            var bunniesData = new Queue<int>();

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        bunniesData.Enqueue(row);
                        bunniesData.Enqueue(col);
                    }
                }
            }

            while (bunniesData.Any())
            {
                int row = bunniesData.Dequeue();
                int col = bunniesData.Dequeue();

                if (IsInsideTheLaid(lair, row, col - 1))
                {
                    lair[row, col - 1] = 'B';
                }
                if (IsInsideTheLaid(lair, row, col + 1))
                {
                    lair[row, col + 1] = 'B';
                }
                if (IsInsideTheLaid(lair, row - 1, col))
                {
                    lair[row - 1, col] = 'B';
                }
                if (IsInsideTheLaid(lair, row + 1, col))
                {
                    lair[row + 1, col] = 'B';
                }
            }

            return lair;
        }


        private static bool IsInsideTheLaid(char[,] lair, int row, int col)
        {

            if (row >= 0 && row < lair.GetLength(0) && col >= 0 && col < lair.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}

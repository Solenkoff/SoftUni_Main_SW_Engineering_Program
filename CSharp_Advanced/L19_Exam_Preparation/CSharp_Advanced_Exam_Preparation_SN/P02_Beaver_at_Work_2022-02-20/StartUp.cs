using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Beaver_at_Work
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] pond = new char[n, n];

            int beaverRow = -1;
            int beaverCol = -1;

            int totalBranchesCount = 0;
            int branchesCollected = 0;
            Stack<char> branches = new Stack<char>();

            for (int row = 0; row < n; row++)
            {
                char[] rowInput = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(char.Parse)
                                         .ToArray();

                for (int col = 0; col < n; col++)
                {
                    pond[row, col] = rowInput[col];

                    if (pond[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    else if (char.IsLower(pond[row, col]))
                    {
                        totalBranchesCount++;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "end" && totalBranchesCount - branchesCollected != 0)
            {
                string direction = command;

                int nextRow = MoveRow(beaverRow, direction);
                int nextCol = MoveCol(beaverCol, direction);

                if (!IsValidPosition(nextRow, nextCol, pond.GetLength(0), pond.GetLength(1)))
                {
                    if (branches.Count > 0)
                    {
                        branches.Pop();
                    }

                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    if (char.IsLower(pond[nextRow, nextCol]))
                    {
                        branchesCollected++;
                        branches.Push(pond[nextRow, nextCol]);
                    }
                    else if (pond[nextRow, nextCol] == 'F')
                    {
                        if (!IsValidPosition(MoveRow(nextRow, direction), MoveCol(nextCol, direction), pond.GetLength(0), pond.GetLength(1)))
                        {
                            switch (direction)
                            {
                                case "up": direction = "down"; break;
                                case "down": direction = "up"; break;
                                case "left": direction = "right"; break;
                                case "right": direction = "left"; break;
                            }
                        }

                        pond[beaverRow, beaverCol] = '-';
                        pond[nextRow, nextCol] = '-';

                        beaverRow = SwimRow(nextRow, direction, n);
                        beaverCol = SwimCol(nextCol, direction, n);

                        if (char.IsLower(pond[beaverRow, beaverCol]))
                        {
                            branchesCollected++;
                            branches.Push(pond[beaverRow, beaverCol]);
                        }

                        pond[beaverRow, beaverCol] = 'B';

                        command = Console.ReadLine();
                        continue;
                    }

                    pond[nextRow, nextCol] = 'B';
                    pond[beaverRow, beaverCol] = '-';

                    beaverRow = nextRow;
                    beaverCol = nextCol;

                }

                command = Console.ReadLine();
            }

            if(totalBranchesCount - branchesCollected == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranchesCount - branchesCollected} branches left.");
            }

            PrintPond(pond);

        }

        private static int SwimCol(int col, string direction, int n)
        {
            if (direction == "left")
            {
                return 0;
            }
            if (direction == "right")
            {
                return n - 1;
            }

            return col;
        }

        public static int SwimRow(int row, string direction, int n)
        {
            if (direction == "up")
            {
                return 0;
            }
            if (direction == "down")
            {
                return n - 1;
            }

            return row;
        }

        private static bool IsValidPosition(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }

        public static int MoveCol(int col, string direction)
        {
            if (direction == "left")
            {
                return col - 1;
            }
            if (direction == "right")
            {
                return col + 1;
            }

            return col;
        }

        public static int MoveRow(int row, string direction)
        {
            if (direction == "up")
            {
                return row - 1;
            }
            if (direction == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static void PrintPond(char[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

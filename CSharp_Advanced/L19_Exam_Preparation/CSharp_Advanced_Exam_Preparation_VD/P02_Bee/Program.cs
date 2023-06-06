using System;

namespace P02_Bee
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (matrix[row, col] == 'B')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            int currRow = startRow;
            int currCol = startCol;

            int polinatedFlowers = 0;

            string input = Console.ReadLine();

            while (input != "End")
            {
                matrix[currRow, currCol] = '.';

                currRow = MoveRow(currRow, input);
                currCol = MoveCol(currCol, input);

                if (!IsValidPosition(currRow, currCol, n, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[currRow, currCol] == 'f')
                {
                    polinatedFlowers++;
                }

                if (matrix[currRow, currCol] == 'O')
                {
                    matrix[currRow, currCol] = '.';
                    currRow = MoveRow(currRow, input);
                    currCol = MoveCol(currCol, input);
                    if (!IsValidPosition(currRow, currCol, n, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (matrix[currRow, currCol] == 'f')
                    {
                        polinatedFlowers++;
                    }
                }


                matrix[currRow, currCol] = 'B';

                input = Console.ReadLine();
            }


            if (polinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }

            PrintTerritory(matrix);

        }

        public static void PrintTerritory(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static int MoveCol(int currCol, string direction)
        {
            if (direction == "left")
            {
                return currCol - 1;
            }
            else if (direction == "right")
            {
                return currCol + 1;
            }

            return currCol;
        }

        public static int MoveRow(int currRow, string direction)
        {
            if (direction == "up")
            {
                return currRow - 1;
            }
            else if (direction == "down")
            {
                return currRow + 1;
            }

            return currRow;
        }

        public static bool IsValidPosition(int currRow, int currCol, int rows, int cols)
        {
            return currRow >= 0 && currCol >= 0 && currRow < rows && currCol < cols;
        }
    }
}

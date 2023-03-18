using System;
using System.Linq;

namespace _03_Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rowsCols = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int maxSum = int.MinValue;
            int maxSumRow = -1;
            int maxSumCol = -1;

            if (rows >= 3 && cols >= 3)
            {
                for (int row = 0; row <= rows - 3; row++)
                {
                    for (int col = 0; col <= cols - 3; col++)
                    {
                        int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                        if(currSum > maxSum)
                        {
                            maxSum = currSum;
                            maxSumRow = row;
                            maxSumCol = col;
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(matrix[maxSumRow + row, maxSumCol + col] + " ");
                }
                Console.WriteLine();
            }
   
        }
    }
}

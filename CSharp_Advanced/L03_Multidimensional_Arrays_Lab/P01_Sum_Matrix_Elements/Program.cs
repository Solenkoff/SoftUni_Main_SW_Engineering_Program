using System;
using System.Linq;

namespace _01_Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int sum = 0;

            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);

        }
    }
}

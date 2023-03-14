using System;
using System.Linq;

namespace _03_Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {

            int inputN = int.Parse(Console.ReadLine());

            int[,] matrix = new int[inputN, inputN];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int primeDiagonalSum = 0;

            for (int i = 0; i < inputN; i++)
            {
                primeDiagonalSum += matrix[i,i];
            }

            Console.WriteLine(primeDiagonalSum);

        }
    }
}

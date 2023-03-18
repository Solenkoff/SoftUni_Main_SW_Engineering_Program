using System;
using System.Linq;

namespace _02_Squares_In_Matrix
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

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] matrixData = Console.ReadLine().Split(' ');


                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = matrixData[col];
                }            
            }

            int legitSquares = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        legitSquares++;
                    }
                }
            }

            Console.WriteLine(legitSquares);
            
        }
    }
}

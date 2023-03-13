using System;
using System.Linq;

namespace _04_Symbol_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int inputN = int.Parse(Console.ReadLine());

            char[,] matrix = new char[inputN, inputN];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                                       
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            char ch = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == ch)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{ch} does not occur in the matrix");

        }
    }
}

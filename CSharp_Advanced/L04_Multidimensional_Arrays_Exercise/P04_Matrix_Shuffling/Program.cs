using System;
using System.Linq;

namespace _04_Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rowsCols = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
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

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commands.Length != 5 || commands[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string command = commands[0];
                    int firstRow = int.Parse(commands[1]);
                    int firstCol = int.Parse(commands[2]);
                    int secondRow = int.Parse(commands[3]);
                    int secondCol = int.Parse(commands[4]);

                    if((firstRow < 0 || firstRow > rows -1) || (firstCol < 0 || firstCol > cols - 1) ||
                        (secondRow < 0 || secondRow > rows - 1) || (secondCol < 0 || secondCol > cols - 1))
                    {
                        Console.WriteLine("Invalid input!");
                        input = Console.ReadLine();
                        continue;
                    }

                    string tempElement = matrix[firstRow, firstCol];
                    matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                    matrix[secondRow, secondCol] = tempElement;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                
                input = Console.ReadLine();

            }  
            
        }
    }
}

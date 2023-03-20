using System;
using System.Linq;

namespace _06_Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            var matrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] rowData = Console.ReadLine()
                                       .Split()
                                       .Select(double.Parse)
                                       .ToArray();
                matrix[row] = rowData;
      
            }

            for (int row = 0; row < n - 1; row++)
            {
                if(matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] = matrix[row][i] * 2;
                        matrix[row + 1][i] = matrix[row + 1][i] * 2;
                    }
                }
                else
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] = matrix[row][i] / 2;                     
                    }
                    for (int i = 0; i < matrix[row + 1].Length; i++)
                    {
                        matrix[row + 1][i] = matrix[row + 1][i] / 2;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if(command == "Add")
                {
                    int commandRow = int.Parse(commands[1]);
                    int commandCol = int.Parse(commands[2]);
                    double value = double.Parse(commands[3]);

                    if (commandRow >= 0 && commandRow < n && commandCol >= 0 && commandCol < matrix[commandRow].Length)
                    {
                        matrix[commandRow][commandCol] += value;
                    }
                }
                else if (command == "Subtract")
                {
                    int commandRow = int.Parse(commands[1]);
                    int commandCol = int.Parse(commands[2]);
                    double value = double.Parse(commands[3]);

                    if (commandRow >= 0 && commandRow < n && commandCol >= 0 && commandCol < matrix[commandRow].Length)
                    {
                        matrix[commandRow][commandCol] -= value;
                    }
                }
                else if (command == "End")
                {
                    foreach (double[] row in matrix)
                    {
                        Console.WriteLine(string.Join(' ', row));                      
                    }
                    return;
                }

            }
            
        }
    }
}

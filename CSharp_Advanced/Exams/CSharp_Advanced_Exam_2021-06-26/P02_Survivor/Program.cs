using System;
using System.Linq;

namespace P02_Survivor
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(char.Parse)
                                     .ToArray();
            }

            int collectedTokens = 0;
            int opponentsTokens = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] commandsInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandsInput[0];

                int row = int.Parse(commandsInput[1]);
                int col = int.Parse(commandsInput[2]);

                if (command == "Find")
                {
                    if (IsValid(matrix, row, col))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            matrix[row][col] = '-';

                            collectedTokens++;
                        }
                    }
                }
                else if(command == "Opponent")
                {
                    string direction = commandsInput[3];

                    if (IsValid(matrix, row, col))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            matrix[row][col] = '-';

                            opponentsTokens++;
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            switch (direction)
                            {
                                case "up": row--; break;
                                case "down": row++; break;
                                case "left": col--; break;
                                case "right": col++; break;
                            }

                            if (IsValid(matrix, row, col))
                            {
                                if (matrix[row][col] == 'T')
                                {
                                    matrix[row][col] = '-';

                                    opponentsTokens++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentsTokens}");
        }


        private static bool IsValid(char[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix[row].Length;
        }
    }
}

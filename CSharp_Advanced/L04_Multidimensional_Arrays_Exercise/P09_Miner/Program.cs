using System;
using System.Linq;

namespace _09_Miner_
{
    class Program
    {
        static void Main(string[] args)
        {

            int fieldSize = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[fieldSize, fieldSize];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = rowData[col];
                }

            }

            int startRow = -1;
            int startCol = -1;
            int coalCount = 0; 

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    else if (field[row,col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }
           
            int currentRow = startRow;
            int currentCol = startCol;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];

                if (command == "left" && IsValidPosition(field, currentRow, currentCol - 1))
                {
                    currentCol--;

                    if (field[currentRow, currentCol] == 'c')
                    {
                        field[currentRow, currentCol] = '*';
                        coalCount--;
                        if (IsThereAnotherC(field))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                            return;
                        }
                    }
                    else if (field[currentRow, currentCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                        return;
                    }

                }
                if (command == "right" && IsValidPosition(field, currentRow, currentCol + 1))
                {
                    currentCol++;

                    if (field[currentRow, currentCol] == 'c')
                    {
                        field[currentRow, currentCol] = '*';
                        coalCount--;
                        if (IsThereAnotherC(field))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                            return;
                        }
                    }
                    else if (field[currentRow, currentCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                        return;
                    }

                }
                if (command == "up" && IsValidPosition(field, currentRow - 1, currentCol))
                {
                    currentRow--;

                    if (field[currentRow, currentCol] == 'c')
                    {
                        field[currentRow, currentCol] = '*';
                        coalCount--;
                        if (IsThereAnotherC(field))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                            return;
                        }
                    }
                    else if (field[currentRow, currentCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                        return;
                    }

                }
                if (command == "down" && IsValidPosition(field, currentRow + 1, currentCol))
                {
                    currentRow++;

                    if (field[currentRow, currentCol] == 'c')
                    {
                        field[currentRow, currentCol] = '*';
                        coalCount--;
                        if (IsThereAnotherC(field))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                            return;
                        }
                    }
                    else if (field[currentRow, currentCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                        return;
                    }

                }
            }

            Console.WriteLine($"{coalCount} coals left. ({currentRow}, {currentCol})");

        }


        private static bool IsThereAnotherC(char[,] field)
        {
            bool existC = false;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'c')
                    {
                        existC = true;
                    }
                }
            }

            return existC;
        }

        private static bool IsValidPosition(char[,] field, int row, int col)
        {
            if (row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

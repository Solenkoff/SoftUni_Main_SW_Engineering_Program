using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Warships
{
    class Program
    {
        static void Main(string[] args)
        {

            int fieldSize = int.Parse(Console.ReadLine());

            Queue<int> commands = new Queue<int>();

            int[] commandsData = Console.ReadLine()
                                        .Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            foreach (var item in commandsData)
            {
                commands.Enqueue(item);
            }

            string[,] field = new string[fieldSize, fieldSize];

            int shipsCount1 = 0;
            int shipsCount2 = 0;
            int totalCountShipsDestroyed = 0;

            for (int row = 0; row < fieldSize; row++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = rowData[col];
                    if (field[row, col] == "<")
                    {
                        shipsCount1++;
                    }
                    else if (field[row, col] == ">")
                    {
                        shipsCount2++;
                    }

                }
            }

            while (commands.Any())
            {
                int currRow = commands.Dequeue();
                int currCol = commands.Dequeue();

                if (IsValidPosition(currRow, currCol, fieldSize))
                {

                    if (field[currRow, currCol] == ">")
                    {
                        field[currRow, currCol] = "X";
                        shipsCount2--;
                        totalCountShipsDestroyed++;
                    }
                    else if (field[currRow, currCol] == "<")
                    {
                        field[currRow, currCol] = "X";
                        shipsCount1--;
                        totalCountShipsDestroyed++;
                    }
                    else if (field[currRow, currCol] == "#")
                    {
                        field[currRow, currCol] = "X";

                        if (IsValidPosition(currRow, currCol + 1, fieldSize))
                        {
                            if (field[currRow, currCol + 1] == "<")
                            {
                                shipsCount1--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currRow, currCol + 1] == ">")
                            {
                                shipsCount2--;
                                totalCountShipsDestroyed++;
                            }
                            field[currRow, currCol + 1] = "X";
                        }
                        if (IsValidPosition(currRow, currCol - 1, fieldSize))
                        {
                            if (field[currRow, currCol - 1] == "<")
                            {
                                shipsCount1--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currRow, currCol - 1] == ">")
                            {
                                shipsCount2--;
                                totalCountShipsDestroyed++;
                            }
                            field[currRow, currCol - 1] = "X";
                        }
                        if (IsValidPosition(currRow + 1, currCol, fieldSize))
                        {
                            if (field[currRow + 1, currCol] == "<")
                            {
                                shipsCount1--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currRow + 1, currCol] == ">")
                            {
                                shipsCount2--;
                                totalCountShipsDestroyed++;
                            }
                            field[currRow + 1, currCol] = "X";
                        }
                        if (IsValidPosition(currRow - 1, currCol, fieldSize))
                        {
                            if (field[currRow - 1, currCol] == "<")
                            {
                                shipsCount1--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currRow - 1, currCol] == ">")
                            {
                                shipsCount2--;
                                totalCountShipsDestroyed++;
                            }
                            field[currRow - 1, currCol] = "X";
                        }
                        if (IsValidPosition(currRow + 1, currCol + 1, fieldSize))
                        {
                            if (field[currRow + 1, currCol + 1] == "<")
                            {
                                shipsCount1--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currRow + 1, currCol + 1] == ">")
                            {
                                shipsCount2--;
                                totalCountShipsDestroyed++;
                            }
                            field[currRow + 1, currCol + 1] = "X";
                        }
                        if (IsValidPosition(currRow - 1, currCol + 1, fieldSize))
                        {
                            if (field[currRow - 1, currCol + 1] == "<")
                            {
                                shipsCount1--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currRow - 1, currCol + 1] == ">")
                            {
                                shipsCount2--;
                                totalCountShipsDestroyed++;
                            }
                            field[currRow - 1, currCol + 1] = "X";
                        }
                        if (IsValidPosition(currRow + 1, currCol - 1, fieldSize))
                        {
                            if (field[currRow  + 1, currCol - 1] == "<")
                            {
                                shipsCount1--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currRow + 1, currCol - 1] == ">")
                            {
                                shipsCount2--;
                                totalCountShipsDestroyed++;
                            }
                            field[currRow + 1, currCol - 1] = "X";
                        }
                        if (IsValidPosition(currRow - 1, currCol - 1, fieldSize))
                        {
                            if (field[currRow - 1, currCol - 1] == "<")
                            {
                                shipsCount1--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[currRow - 1, currCol - 1] == ">")
                            {
                                shipsCount2--;
                                totalCountShipsDestroyed++;
                            }
                            field[currRow - 1, currCol - 1] = "X";
                        }
                    }                
                }

                if (shipsCount1 == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} " +
                                      $"ships have been sunk in the battle.");
                    return;
                }
                else if (shipsCount2 == 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} " +
                                      $"ships have been sunk in the battle.");                  
                    return;
                }              
            }

            Console.WriteLine($"It's a draw! Player One has {shipsCount1} left. Player Two has {shipsCount2} left.");
            
        }
   
        public static bool IsValidPosition(int row, int col, int fieldSize)
        {
            if (row >= 0 && row < fieldSize && col >= 0 && col < fieldSize)
            {
                return true;
            }

            return false;
        }
    }
}

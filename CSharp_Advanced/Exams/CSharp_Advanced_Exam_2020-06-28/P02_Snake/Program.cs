using System;

namespace P02_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] territory = new char[n,n];

            int snakeStartRow = -1;
            int snakeStartCol = -1;

            for (int row = 0; row < territory.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    territory[row, col] = rowInput[col];

                    if(territory[row, col] == 'S')
                    {
                        snakeStartRow = row;
                        snakeStartCol = col;
                    }
                }
            }


            int foodQuantity = 0;
            

            int currRow = snakeStartRow;
            int currCol = snakeStartCol;

            

            while (true)
            {
                string command = Console.ReadLine();

                territory[currRow, currCol] = '.';

                if (command == "up")
                {
                    currRow--;
                    
                }
                else if (command == "down")
                {
                    currRow++;
                }
                else if (command == "left")
                {
                    currCol--;
                }
                else if (command == "right")
                {
                    currCol++;
                }

                bool validPosition = IsValidPosition(territory, currRow, currCol);
                if (validPosition)
                {
                    if (territory[currRow, currCol] == '*')
                    {
                        foodQuantity++;
                    }
                    else if (territory[currRow, currCol] == 'B')
                    {
                        territory[currRow, currCol] = '.';
                        int[] positionOfB = FindOtherB(territory);
                        currRow = positionOfB[0];
                        currCol = positionOfB[1];
                    }

                    territory[currRow, currCol] = 'S';
                }
                else
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if(foodQuantity >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");


            PrintTerritory(territory);
            

        }

        private static void PrintTerritory(char[,] territory)
        {
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row,col]);
                }

                Console.WriteLine();
            }
        }

        private static int[] FindOtherB(char[,] territory)
        {
            int[] positionOfB = new int[2];

            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    if(territory[row,col] == 'B')
                    {
                        positionOfB[0] = row;
                        positionOfB[1] = col;
                    }
                }
            }

            return positionOfB;
        }

        private static bool IsValidPosition(char[,] territory, int currRow, int currCol)
        {
            return currRow >= 0 && currCol >= 0 && currRow < territory.GetLength(0) && currCol < territory.GetLength(1);
        }
    }
}

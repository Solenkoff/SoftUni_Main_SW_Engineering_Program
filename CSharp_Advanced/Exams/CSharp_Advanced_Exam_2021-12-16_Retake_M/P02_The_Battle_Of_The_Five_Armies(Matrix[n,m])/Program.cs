using System;

namespace P02_The_Battle_Of_The_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            string firstRrowInput = Console.ReadLine();

            char[,] map = new char[rows, firstRrowInput.Length];

            int currRow = -1;
            int currCol = -1;

            for (int firstRowCol = 0; firstRowCol < map.GetLength(1); firstRowCol++)
            {
                map[0, firstRowCol] = firstRrowInput[firstRowCol];

                if (map[0, firstRowCol] == 'A')
                {
                    currRow = 0;
                    currCol = firstRowCol;
                }
            }

            for (int row = 1; row < map.GetLength(0); row++)
            {
                char[] rowINput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < map.GetLength(1); col++)
                {
                    map[row, col] = rowINput[col];

                    if (map[row, col] == 'A')
                    {
                        currRow = row;
                        currCol = col;
                    }

                }
            }


            bool throneReached = false;

            while (armor > 0)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = input[0];
                int rowO = int.Parse(input[1]);
                int colO = int.Parse(input[2]);

                map[rowO, colO] = 'O';
                map[currRow, currCol] = '-';

                currRow = MoveRow(currRow, direction, map.GetLength(0));
                currCol = MoveCol(currCol, direction, map.GetLength(1));

                armor--;
                 
                if(map[currRow, currCol] == 'O')
                {
                    armor -= 2;
                    if (armor <= 0)
                    {
                        map[currRow, currCol] = 'X';
                        Console.WriteLine($"The army was defeated at {currRow};{currCol}.");
                        break;
                    }
                }
                if(map[currRow, currCol] == 'M')
                {
                    throneReached = true;
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    map[currRow, currCol] = '-';
                    break;
                }
                
            }


            PrintMap(map);

        }


        

        public static int MoveCol(int currCol, string direction, int size)
        {
            if (direction == "left" && currCol - 1 >= 0)
            {
                return currCol - 1;
            }
            else if (direction == "right" && currCol + 1 < size)
            {
                return currCol + 1;
            }

            return currCol;
        }

        public static int MoveRow(int currRow, string direction, int size)
        {
            if (direction == "up" && currRow - 1 >= 0)
            {
                return currRow - 1;
            }
            else if (direction == "down" && currRow + 1 < size)
            {
                return currRow + 1;
            }

            return currRow;
        }

        public static void PrintMap(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

    }
}

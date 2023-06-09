using System;

namespace P02_Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] currRowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRowInput[col];

                    if (matrix[row, col] == 'f')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }


            int currRow = startRow;
            int currCol = startCol;
            bool hasWon = false;

            for (int i = 0; i < commandsCount; i++)
            {

                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (IsValid(currRow - 1, n))
                    {
                        if (matrix[currRow - 1, currCol] == 'F')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[currRow - 1, currCol] = 'f';
                            hasWon = true;
                            break;
                        }
                        else if (matrix[currRow - 1, currCol] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[currRow - 1, currCol] == 'B')
                        {
                            matrix[currRow, currCol] = '-';
                            if (IsValid(currRow - 2, n))
                            {
                                currRow -= 2;
                            }
                            else
                            {
                                currRow = n - 1;
                            }

                        }
                        else if (matrix[currRow - 1, currCol] == '-')
                        {
                            matrix[currRow, currCol] = '-';
                            currRow--;
                        }

                        matrix[currRow, currCol] = 'f';
                    }
                    else
                    {
                        if (matrix[n - 1, currCol] == 'F')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[n - 1, currCol] = 'f';
                            hasWon = true;
                            break;
                        }
                        else if (matrix[n - 1, currCol] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[n - 1, currCol] == 'B')
                        {
                            matrix[currRow, currCol] = '-';
                            currRow = n - 2;
                        }
                        else if (matrix[n - 1, currCol] == '-')
                        {
                            matrix[currRow, currCol] = '-';
                            currRow = n - 1;
                        }

                        matrix[currRow, currCol] = 'f';
                    }
                }
                else if (command == "down")
                {
                    if (IsValid(currRow + 1, n))
                    {
                        if (matrix[currRow + 1, currCol] == 'F')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[currRow + 1, currCol] = 'f';
                            hasWon = true;
                            break;
                        }
                        else if (matrix[currRow + 1, currCol] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[currRow + 1, currCol] == 'B')
                        {
                            matrix[currRow, currCol] = '-';
                            if (IsValid(currRow + 2, n))
                            {
                                currRow += 2;
                            }
                            else
                            {
                                currRow = 0;
                            }

                        }
                        else if (matrix[currRow + 1, currCol] == '-')
                        {
                            matrix[currRow, currCol] = '-';
                            currRow++;
                        }

                        matrix[currRow, currCol] = 'f';
                    }
                    else
                    {
                        if (matrix[0, currCol] == 'F')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[0, currCol] = 'f';
                            hasWon = true;
                            break;
                        }
                        else if (matrix[0, currCol] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[0, currCol] == 'B')
                        {
                            matrix[currRow, currCol] = '-';
                            currRow = 1;
                        }
                        else if (matrix[0, currCol] == '-')
                        {
                            matrix[currRow, currCol] = '-';
                            currRow = 0;
                        }

                        matrix[currRow, currCol] = 'f';
                    }
                }
                else if (command == "left")
                {
                    if (IsValid(currCol - 1, n))
                    {
                        if (matrix[currRow, currCol - 1] == 'F')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[currRow, currCol -1] = 'f';
                            hasWon = true;
                            break;
                        }
                        else if (matrix[currRow, currCol - 1] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[currRow, currCol - 1] == 'B')
                        {
                            matrix[currRow, currCol] = '-';
                            if (IsValid(currCol - 2, n))
                            {
                                currCol -= 2;
                            }
                            else
                            {
                                currCol = n - 1;
                            }

                        }
                        else if (matrix[currRow, currCol - 1] == '-')
                        {
                            matrix[currRow, currCol] = '-';
                            currCol--;
                        }

                        matrix[currRow, currCol] = 'f';
                    }
                    else
                    {
                        if (matrix[currRow, n - 1] == 'F')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[currRow, n - 1] = 'f';
                            hasWon = true;
                            break;
                        }
                        else if (matrix[currRow, n - 1] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[currRow, n - 1] == 'B')
                        {
                            matrix[currRow, currCol] = '-';
                            currCol = n - 2;
                        }
                        else if (matrix[currRow, n - 1] == '-')
                        {
                            matrix[currRow, currCol] = '-';
                            currCol = n - 1;
                        }

                        matrix[currRow, currCol] = 'f';
                    }
                }
                else if (command == "right")
                {
                    if (IsValid(currCol + 1, n))
                    {
                        if (matrix[currRow, currCol + 1] == 'F')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[currRow, currCol + 1] = 'f';
                            hasWon = true;
                            break;
                        }
                        else if (matrix[currRow, currCol + 1] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[currRow, currCol + 1] == 'B')
                        {
                            matrix[currRow, currCol] = '-';
                            if (IsValid(currCol + 2, n))
                            {
                                currCol += 2;
                            }
                            else
                            {
                                currCol = 0;
                            }

                        }
                        else if (matrix[currRow, currCol + 1] == '-')
                        {
                            matrix[currRow, currCol] = '-';
                            currCol++;
                        }

                        matrix[currRow, currCol] = 'f';
                    }
                    else
                    {
                        if (matrix[currRow, 0] == 'F')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[currRow, 0] = 'f';
                            hasWon = true;
                            break;
                        }
                        else if (matrix[currRow, 0] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[currRow, 0] == 'B')
                        {
                            matrix[currRow, currCol] = '-';
                            currCol = 1;
                        }
                        else if (matrix[currRow, 0] == '-')
                        {
                            matrix[currRow, currCol] = '-';
                            currCol = 0;
                        }

                        matrix[currRow, currCol] = 'f';
                    }
                }
            }

            if(hasWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }


        }

        private static bool IsValid(int rowCol, int n)
        {
            return rowCol >= 0 && rowCol < n;
        }
    }
}

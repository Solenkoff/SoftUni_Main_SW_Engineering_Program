using System;

namespace P02_Bee
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] currRowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRowInput[col];

                    if (matrix[row, col] == 'B')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }

            }

            int currRow = startRow;
            int currCol = startCol;

            int polinatedF = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else if (input == "up")
                {
                    if (!IsValid(currRow - 1, n))
                    {
                        matrix[currRow, currCol] = '.';
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    matrix[currRow, currCol] = '.';

                    currRow--;

                    if (matrix[currRow, currCol] == 'f')
                    {
                        polinatedF++;
                    }
                    else if (matrix[currRow, currCol] == 'O')
                    {                       
                        if (!IsValid(currRow - 1, n))
                        {
                            matrix[currRow, currCol] = 'B';
                            Console.WriteLine("The bee got lost!");
                            break;
                        }

                        matrix[currRow, currCol] = '.';
                        currRow--;
                        if (matrix[currRow, currCol] == 'f')
                        {
                            polinatedF++;
                        }
                    }

                    matrix[currRow, currCol] = 'B';
                }
                else if (input == "down")
                {
                    if (!IsValid(currRow + 1, n))
                    {
                        matrix[currRow, currCol] = '.';
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    matrix[currRow, currCol] = '.';

                    currRow++;

                    if (matrix[currRow, currCol] == 'f')
                    {
                        polinatedF++;
                    }
                    else if (matrix[currRow, currCol] == 'O')
                    {
                        if (!IsValid(currRow + 1, n))
                        {
                            matrix[currRow, currCol] = 'B';
                            Console.WriteLine("The bee got lost!");
                            break;
                        }

                        matrix[currRow, currCol] = '.';
                        currRow++;
                        if (matrix[currRow, currCol] == 'f')
                        {
                            polinatedF++;
                        }
                    }

                    matrix[currRow, currCol] = 'B';
                }
                else if (input == "left")
                {
                    if (!IsValid(currCol - 1, n))
                    {
                        matrix[currRow, currCol] = '.';
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    matrix[currRow, currCol] = '.';

                    currCol--;

                    if (matrix[currRow, currCol] == 'f')
                    {
                        polinatedF++;
                    }
                    else if (matrix[currRow, currCol] == 'O')
                    {
                        if (!IsValid(currCol - 1, n))
                        {
                            matrix[currRow, currCol] = 'B';
                            Console.WriteLine("The bee got lost!");
                            break;
                        }

                        matrix[currRow, currCol] = '.';
                        currCol--;
                        if (matrix[currRow, currCol] == 'f')
                        {
                            polinatedF++;
                        }
                    }

                    matrix[currRow, currCol] = 'B';
                }
                else if (input == "right")
                {
                    if (!IsValid(currCol + 1, n))
                    {
                        matrix[currRow, currCol] = '.';
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    matrix[currRow, currCol] = '.';

                    currCol++;

                    if (matrix[currRow, currCol] == 'f')
                    {
                        polinatedF++;
                    }
                    else if (matrix[currRow, currCol] == 'O')
                    {
                        if (!IsValid(currCol + 1, n))
                        {
                            matrix[currRow, currCol] = 'B';
                            Console.WriteLine("The bee got lost!");
                            break;
                        }

                        matrix[currRow, currCol] = '.';
                        currCol++;
                        if (matrix[currRow, currCol] == 'f')
                        {
                            polinatedF++;
                        }
                    }

                    matrix[currRow, currCol] = 'B';
                }
            }


            if (polinatedF < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedF} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedF} flowers!");
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

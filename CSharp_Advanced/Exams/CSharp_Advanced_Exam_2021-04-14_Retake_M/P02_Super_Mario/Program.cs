using System;

namespace P02_Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {

            //  !!!   To Change the Square Matrix with a rectanguler one


            int eM = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());


            char[,] matrix = new char[n, n];

            int startRow = 0;
            int startCol = 0;

            if(n > 0)
            {
                for (int row = 0; row < n; row++)
                {
                    char[] currRowInput = Console.ReadLine().ToCharArray();

                    for (int col = 0; col < n; col++)
                    {
                        matrix[row, col] = currRowInput[col];

                        if (matrix[row, col] == 'M')
                        {
                            startRow = row;
                            startCol = col;
                        }
                    }
                }
            }

            

            int currRow = startRow;
            int currCol = startCol;

            bool isDead = false;
            int rowDead = 0;
            int colDead = 0;

            while (eM > 0)
            {
                string[] input = Console.ReadLine().Split();

                string direction = input[0];
                int rowB = int.Parse(input[1]);
                int colB = int.Parse(input[2]);

                matrix[rowB, colB] = 'B';

                eM--;

                if(direction == "W")  // Up
                {
                    if(!ValidPosition(currRow - 1, n))
                    {
                        if(eM <= 0)
                        {
                            isDead = true;
                            rowDead = currRow;
                            colDead = currCol;
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        if(matrix[currRow - 1, currCol] == 'B')
                        {
                            eM -= 2;
                            if (eM <= 0)
                            {
                                isDead = true;
                                rowDead = currRow - 1;
                                colDead = currCol;
                                matrix[currRow, currCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[currRow, currCol] = '-';
                                currRow--;
                            }
                        }
                        else if(matrix[currRow - 1, currCol] == 'P')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[currRow - 1, currCol] = '-';
                            break;
                        }
                        else
                        {
                            if (eM <= 0)
                            {
                                isDead = true;
                                rowDead = currRow - 1;
                                colDead = currCol;
                                matrix[currRow, currCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[currRow, currCol] = '-';
                                currRow--;
                            }
                            
                        }
                    }
                }
                else if(direction == "S")  // Down
                {
                    if (!ValidPosition(currRow + 1, n))
                    {
                        if (eM <= 0)
                        {
                            isDead = true;
                            rowDead = currRow;
                            colDead = currCol;
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        if (matrix[currRow + 1, currCol] == 'B')
                        {
                            eM -= 2;
                            if (eM <= 0)
                            {
                                isDead = true;
                                rowDead = currRow + 1;
                                colDead = currCol;
                                matrix[currRow, currCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[currRow, currCol] = '-';
                                currRow++;
                            }
                        }
                        else if (matrix[currRow + 1, currCol] == 'P')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[currRow + 1, currCol] = '-';
                            break;
                        }
                        else
                        {
                            if (eM <= 0)
                            {
                                isDead = true;
                                rowDead = currRow + 1;
                                colDead = currCol;
                                matrix[currRow, currCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[currRow, currCol] = '-';
                                currRow++;
                            }
                           
                        }
                    }
                }
                else if (direction == "A")   // Left
                {
                    if (!ValidPosition(currCol - 1, n))
                    {
                        if (eM <= 0)
                        {
                            isDead = true;
                            rowDead = currRow;
                            colDead = currCol;
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        if (matrix[currRow, currCol - 1] == 'B')
                        {
                            eM -= 2;
                            if (eM <= 0)
                            {
                                isDead = true;
                                rowDead = currRow;
                                colDead = currCol - 1;
                                matrix[currRow, currCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[currRow, currCol] = '-';
                                currCol--;
                            }
                        }
                        else if (matrix[currRow, currCol - 1] == 'P')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[currRow, currCol - 1] = '-';
                            break;
                        }
                        else
                        {
                            if (eM <= 0)
                            {
                                isDead = true;
                                rowDead = currRow;
                                colDead = currCol - 1;
                                matrix[currRow, currCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[currRow, currCol] = '-';
                                currCol--;
                            }
                           
                        }
                    }
                }
                else if (direction == "D")   // Right
                {
                    if (!ValidPosition(currCol + 1, n))
                    {
                        if (eM <= 0)
                        {
                            isDead = true;
                            rowDead = currRow;
                            colDead = currCol;
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        if (matrix[currRow, currCol + 1] == 'B')
                        {
                            eM -= 2;
                            if (eM <= 0)
                            {
                                isDead = true;
                                rowDead = currRow;
                                colDead = currCol + 1;
                                matrix[currRow, currCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[currRow, currCol] = '-';
                                currCol++;
                            }
                        }
                        else if (matrix[currRow, currCol + 1] == 'P')
                        {
                            matrix[currRow, currCol] = '-';
                            matrix[currRow, currCol + 1] = '-';
                            break;
                        }
                        else
                        {
                            if (eM <= 0)
                            {
                                isDead = true;
                                rowDead = currRow;
                                colDead = currCol + 1;
                                matrix[currRow, currCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[currRow, currCol] = '-';
                                currCol++;
                            }
                           
                        }
                    }
                }

                matrix[currRow, currCol] = 'M';
            }


            if(isDead == true)
            {
                matrix[rowDead, colDead] = 'X';
                Console.WriteLine($"Mario died at {rowDead};{colDead}.");
            }
            else 
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {eM}");
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

       

        private static bool ValidPosition(int rowCol, int n)
        {
            return rowCol >= 0 && rowCol < n;
        }
    }
}

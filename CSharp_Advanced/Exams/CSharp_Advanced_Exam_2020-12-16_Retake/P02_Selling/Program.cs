using System;

namespace P02_Selling
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());


            char[,] matrix = new char[n,n];


            int startRowS = -1;
            int startColS = -1;

            int rowFirstO = -1;
            int colFirstO = -1;

            int rowSecondO = -1;
            int colSecondO = -1;

            for (int row = 0; row < n; row++)
            {
                char[] currRowInput = Console.ReadLine().ToCharArray();
               
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRowInput[col];

                    if(matrix[row, col] == 'S')
                    {
                        startRowS = row;
                        startColS = col;
                    }
                    if (matrix[row, col] == 'O')
                    {
                        if(rowFirstO == -1)
                        {
                            rowFirstO = row;
                            colFirstO = col;
                        }
                        else
                        {
                            rowSecondO = row;
                            colSecondO = col;
                        }             
                    }
                }
            }

            int money = 0;

            int currRow = startRowS;
            int currCol = startColS;

            bool wentOut = false;

            while (money < 50)
            {
                string commands = Console.ReadLine();

                matrix[currRow, currCol] = '-';

                if(commands == "down")
                {
                    if(!IsValidPosition(currRow + 1, n))
                    {
                        matrix[currRow, currCol] = '-';
                        wentOut = true;
                        break;
                    }
                    else if (char.IsNumber(matrix[currRow + 1, currCol]))
                    {
                        matrix[currRow, currCol] = '-';
                        int numValue = int.Parse(matrix[currRow + 1, currCol].ToString());
                        money += numValue;
                        currRow++;
                    }
                    else if(matrix[currRow + 1, currCol] == 'O')
                    {
                        if(currRow + 1 == rowFirstO && currCol == colFirstO)
                        {
                            currRow = rowSecondO;
                            currCol = colSecondO;
                            matrix[rowFirstO, colFirstO] = '-';
                        }
                        else if(currRow + 1 == rowSecondO && currCol == colSecondO)
                        {
                            currRow = rowFirstO;
                            currCol = colFirstO;
                            matrix[rowSecondO, colSecondO] = '-';
                        }
                    }
                    else if(matrix[currRow + 1, currCol] == '-')
                    {
                        matrix[currRow, currCol] = '-';
                        currRow++;
                    }
                    matrix[currRow, currCol] = 'S';
                }
                else if(commands == "up")
                {
                    if (!IsValidPosition(currRow - 1, n))
                    {
                        matrix[currRow, currCol] = '-';
                        wentOut = true;
                        break;
                    }
                    else if (char.IsNumber(matrix[currRow - 1, currCol]))
                    {
                        matrix[currRow, currCol] = '-';
                        int numValue = int.Parse(matrix[currRow - 1, currCol].ToString());
                        money += numValue;
                        currRow--;
                    }
                    else if (matrix[currRow - 1, currCol] == 'O')
                    {
                        if (currRow - 1 == rowFirstO && currCol == colFirstO)
                        {
                            currRow = rowSecondO;
                            currCol = colSecondO;
                            matrix[rowFirstO, colFirstO] = '-';
                        }
                        else if (currRow - 1 == rowSecondO && currCol == colSecondO)
                        {
                            currRow = rowFirstO;
                            currCol = colFirstO;
                            matrix[rowSecondO, colSecondO] = '-';
                        }
                    }
                    else if (matrix[currRow - 1, currCol] == '-')
                    {
                        matrix[currRow, currCol] = '-';
                        currRow--;
                    }
                    matrix[currRow, currCol] = 'S';
                }
                else if (commands == "left")
                {
                    if (!IsValidPosition(currCol - 1, n))
                    {
                        matrix[currRow, currCol] = '-';
                        wentOut = true;
                        break;
                    }
                    else if (char.IsNumber(matrix[currRow, currCol - 1]))
                    {
                        matrix[currRow, currCol] = '-';
                        int numValue = int.Parse(matrix[currRow, currCol - 1].ToString());
                        money += numValue;
                        currCol--;
                    }
                    else if (matrix[currRow, currCol - 1] == 'O')
                    {
                        if (currRow == rowFirstO && currCol - 1 == colFirstO)
                        {
                            currRow = rowSecondO;
                            currCol = colSecondO;
                            matrix[rowFirstO, colFirstO] = '-';
                        }
                        else if (currRow == rowSecondO && currCol - 1 == colSecondO)
                        {
                            currRow = rowFirstO;
                            currCol = colFirstO;
                            matrix[rowSecondO, colSecondO] = '-';
                        }
                    }
                    else if (matrix[currRow, currCol - 1] == '-')
                    {
                        matrix[currRow, currCol] = '-';
                        currCol--;
                    }
                    matrix[currRow, currCol] = 'S';
                }
                else if (commands == "right")
                {
                    if (!IsValidPosition(currCol + 1, n))
                    {
                        matrix[currRow, currCol] = '-';
                        wentOut = true;
                        break;
                    }
                    else if (char.IsNumber(matrix[currRow, currCol + 1]))
                    {
                        matrix[currRow, currCol] = '-';
                        int numValue = int.Parse(matrix[currRow, currCol + 1].ToString());
                        money += numValue;
                        currCol++;
                    }
                    else if (matrix[currRow, currCol + 1] == 'O')
                    {
                        if (currRow == rowFirstO && currCol + 1 == colFirstO)
                        {
                            currRow = rowSecondO;
                            currCol = colSecondO;
                            matrix[rowFirstO, colFirstO] = '-';
                        }
                        else if (currRow == rowSecondO && currCol + 1 == colSecondO)
                        {
                            currRow = rowFirstO;
                            currCol = colFirstO;
                            matrix[rowSecondO, colSecondO] = '-';
                        }
                    }
                    else if (matrix[currRow, currCol + 1] == '-')
                    {
                        matrix[currRow, currCol] = '-';
                        currCol++;
                    }
                    matrix[currRow, currCol] = 'S';
                }
            }

            if(wentOut)
            {
                Console.WriteLine($"Bad news, you are out of the bakery.");          
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

        }

        private static bool IsValidPosition(int rowCol, int n )
        {
            return rowCol >= 0 && rowCol < n;
        }
    }
}

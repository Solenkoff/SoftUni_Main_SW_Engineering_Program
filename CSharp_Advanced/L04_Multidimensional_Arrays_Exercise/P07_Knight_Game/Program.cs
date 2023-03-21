using System;

namespace _07_Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            int boardSize = int.Parse(Console.ReadLine());
           
            int rows = boardSize;
            int cols = boardSize;

            var board = new char[rows, cols];

            for (int row = 0; row < boardSize; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < boardSize; col++)
                {
                    board[row, col] = rowData[col];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int maxHits = 0;
                int knightRow = -1;
                int knightCol = -1;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        char element = board[row, col];

                        if (element != 'K')
                        {
                            continue;
                        }

                        int hits = GetCountOfKnightsHits(board, row, col);

                        if (hits > maxHits)
                        {
                            maxHits = hits;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxHits == 0)
                {
                    break;
                }

                board[knightRow, knightCol] = '0';
                removedKnights++;
                
            }

            Console.WriteLine(removedKnights);
     
        }

        private static int GetCountOfKnightsHits(char[,] board, int row, int col)
        {
            int hits = 0;

            if(KnightExists(board, row - 2, col - 1))
            {
                hits++;
            }

            if (KnightExists(board, row - 2, col + 1))
            {
                hits++;
            }
            if (KnightExists(board, row - 1, col - 2))
            {
                hits++;
            }
            if (KnightExists(board, row - 1, col + 2))
            {
                hits++;
            }
            if (KnightExists(board, row + 1, col - 2))
            {
                hits++;
            }
            if (KnightExists(board, row + 1, col + 2))
            {
                hits++;
            }
            if (KnightExists(board, row + 2, col - 1))
            {
                hits++;
            }
            if (KnightExists(board, row + 2, col + 1))
            {
                hits++;
            }

            return hits;
        }


        private static bool KnightExists(char[,] board, int row, int col)
        {
            int lenght = board.GetLength(0);

            if (!(row >= 0 && row < lenght && col >= 0 && col < lenght))
            {
                return false;
            }

            return board[row, col] == 'K';
        }


    }
}

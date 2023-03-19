using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rowsCols = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            string inputString = Console.ReadLine();
         
            var snake = new Queue<char>(inputString);
            
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if(row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (snake.Any())
                        {
                            matrix[row, col] = snake.Peek();
                            snake.Enqueue(snake.Dequeue());
                        }

                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (snake.Any())
                        {
                            matrix[row, col] = snake.Peek();
                            snake.Enqueue(snake.Dequeue());
                        }
                    }
                }

                
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
         
        }
    }
}

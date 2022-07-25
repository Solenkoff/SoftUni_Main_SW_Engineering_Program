using System;

namespace _07_NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());

            PrintMatrixNumXNum(num);

        }

        private static void PrintMatrixNumXNum(int num)
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }

    }
}

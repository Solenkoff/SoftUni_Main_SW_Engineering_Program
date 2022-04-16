using System;

namespace _03_Exact_Sum_Of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int nNumbers = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < nNumbers; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);

        }
    }
}

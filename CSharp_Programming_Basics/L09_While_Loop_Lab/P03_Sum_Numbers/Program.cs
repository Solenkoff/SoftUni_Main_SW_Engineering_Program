using System;

namespace _03_Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            while (sum < n)
            {
                int inputNum = int.Parse(Console.ReadLine());
                sum += inputNum;
            }
            Console.WriteLine(sum);
        }
    }
}

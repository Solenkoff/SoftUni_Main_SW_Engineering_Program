using System;

namespace _01_Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int time1 = int.Parse(Console.ReadLine());
            int time2 = int.Parse(Console.ReadLine());
            int time3 = int.Parse(Console.ReadLine());
            int timeAllSec = time1 + time2 + time3;
            int min = timeAllSec / 60;
            int sec = timeAllSec % 60;


            Console.WriteLine($"{min}:{sec:d2}");
        }
    }
}

using System;

namespace _07_World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSec = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeInSecPerM = double.Parse(Console.ReadLine());
            double time = distance * timeInSecPerM;
            double delay = Math.Floor(distance / 15) * 12.5;
            double allTime = delay + time;
            if (recordInSec > allTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {allTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {allTime - recordInSec:f2} seconds slower.");
            }
        }
    }
}

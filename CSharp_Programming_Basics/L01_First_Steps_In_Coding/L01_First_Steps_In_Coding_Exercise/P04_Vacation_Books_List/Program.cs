using System;

namespace _04_Vacation_Books_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int pagesInBook = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int daysForReading = int.Parse(Console.ReadLine());
            double allHours = pagesInBook / pagesPerHour;
            double hoursForReadingPerDay = allHours / daysForReading;

            Console.WriteLine(hoursForReadingPerDay);
        }
    }
}

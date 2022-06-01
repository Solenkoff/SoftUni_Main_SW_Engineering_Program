using System;

namespace _01_Day_Of_Week
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] days = new[]
           {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            int dayNum = int.Parse(Console.ReadLine());
            if (dayNum < 1 || dayNum > days.Length)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(days[dayNum - 1]);
            }

        }
    }
}

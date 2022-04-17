using System;

namespace _04_Centuries_To_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {

            int nCenturies = int.Parse(Console.ReadLine());

            int years = nCenturies * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int min = hours * 60;

            Console.WriteLine($"{nCenturies} centuries = {years} " +
                $"years = {days} days = {hours} hours = {min} minutes");

        }
    }
}

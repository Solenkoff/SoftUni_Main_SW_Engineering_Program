using System;

namespace _02_Radians_To_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double radians = double.Parse(Console.ReadLine());
            double grade = Math.Round(radians * 180 / Math.PI);

            Console.WriteLine(grade);
        }
    }
}

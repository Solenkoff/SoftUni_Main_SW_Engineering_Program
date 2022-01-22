using System;

namespace _04_Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();
            double result = 0;

            if (input == "mm" && output == "m")
            {
                result = number / 1000;
            }
            else if (input == "m" && output == "mm")
            {
                result = number * 1000;
            }
            else
            if (input == "cm" && output == "m")
            {
                result = number / 100;
            }
            else if (input == "m" && output == "cm")
            {
                result = number * 100;
            }
            else if (input == "mm" && output == "cm")
            {
                result = number / 10;
            }
            else if (input == "cm" && output == "mm")
            {
                result = number * 10;
            }

            Console.WriteLine($"{ result:f3}");
        }
    }
}

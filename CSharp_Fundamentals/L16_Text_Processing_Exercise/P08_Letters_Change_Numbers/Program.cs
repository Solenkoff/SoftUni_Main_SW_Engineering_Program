using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Letters_Change_Numbers_
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<double> output = new List<double>();

            foreach (var item in input)
            {
                char frontLetter = char.Parse(item.Substring(0, 1));
                char rearLetter = char.Parse(item.Substring(item.Length - 1));
                double number = double.Parse(item.Substring(1, item.Length - 2));
                double result = 0.0;
                if (Char.IsUpper(frontLetter))
                {
                    result = number / ((int)frontLetter - 64);

                }
                else
                {
                    result = number * ((int)frontLetter - 96);

                }

                if (Char.IsUpper(rearLetter))
                {
                    result -= ((int)rearLetter - 64);
                }
                else
                {
                    result += ((int)rearLetter - 96);
                }

                output.Add(result);
            }

            double total = output.Sum();

            Console.WriteLine($"{total:f2}");

        }
    }
}

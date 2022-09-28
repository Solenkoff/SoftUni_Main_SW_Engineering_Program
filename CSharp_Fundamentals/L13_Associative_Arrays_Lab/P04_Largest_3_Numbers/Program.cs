namespace P04_Largest_3_Numbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            var threeBest = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", threeBest));

        }
    }
}

namespace P05_Word_Filter
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine()
                   .Split()
                   .Where(word => word.Length % 2 == 0)
                   .ToList()
                   .ForEach(word => Console.WriteLine(word));

        }
    }
}

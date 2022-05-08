using System;

namespace _01_Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            int integer1 = int.Parse(Console.ReadLine());
            int integer2 = int.Parse(Console.ReadLine());
            int integer3 = int.Parse(Console.ReadLine());
            int integer4 = int.Parse(Console.ReadLine());

            int result = (integer1 + integer2) / integer3 * integer4;
            Console.WriteLine(result);

        }
    }
}

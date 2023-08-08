namespace P04_Sum_of_Integers
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {

            string[] elements = Console.ReadLine().Split();

            int sum = 0;

            foreach (var element in elements)
            {
                try
                {
                    int num = Convert.ToInt32(element);

                    sum += num;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch(OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }

                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");

        }

    }
}

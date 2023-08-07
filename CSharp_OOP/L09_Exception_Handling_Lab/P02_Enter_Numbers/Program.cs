namespace P02_Enter_Numbers
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            List<int> nums = new List<int>();

            while (true)
            {
                if (nums.Count == 10)
                {
                    break;
                }

                try
                {
                    int num = ReadNumber(start, end);
                    nums.Add(num);
                    start = num;
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
                catch (IndexOutOfRangeException iorEx)
                {
                    Console.WriteLine(string.Format(iorEx.Message, start));
                }
            }
            
             

            Console.WriteLine(string.Join(", ", nums));
        }

        private static int ReadNumber(int start, int end)
        {
            string number = Console.ReadLine();

            if (!int.TryParse(number, out int num))
            {
                throw new ArgumentException("Invalid Number!");
            }
            if (num <= start || num >= end)
            {
                throw new IndexOutOfRangeException("Your number is not in range {0} - 100!");
            }

            return num;
        }
    }
}

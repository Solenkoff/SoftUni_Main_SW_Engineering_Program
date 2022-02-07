using System;

namespace _06_Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = int.Parse(Console.ReadLine());
            double N2 = int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            double result = 0;

            if (symbol == "+")
            {
                result = N1 + N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} {symbol} { N2} = {result} - {"even"}");
                }
                else
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {result} - {"odd"}");
                }
            }
            else if (symbol == "-")
            {
                result = N1 - N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {result} - {"even"}");
                }
                else
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {result} - {"odd"}");
                }
            }
            else if (symbol == "*")
            {
                result = N1 * N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} {symbol} { N2} = {result} - {"even"}");
                }
                else
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {result} - {"odd"}");
                }
            }
            else if (symbol == "/")
            {
                result = N1 / N2;
                if (N2 != 0)
                {
                    Console.WriteLine($"{N1} / { N2} = {result:f2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }
            else if (symbol == "%")
            {
                result = N1 % N2;
                if (N2 != 0)
                {
                    Console.WriteLine($"{N1} % {N2} = {result}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }
        }
    }
}

using System;
using System.Linq;
using System.Text;

namespace _05_Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            var sb = new StringBuilder();

            string input = Console.ReadLine().TrimStart('0');
            int multiplier = int.Parse(Console.ReadLine());

            int tempDigit = 0;

            if (multiplier == 0 || input == "")
            {
                Console.WriteLine(0);
                return;
            }

            foreach (char character in input.Reverse())
            {
                int charDigit = int.Parse(character.ToString());
                int multiplication = charDigit * multiplier + tempDigit;
                int lastDigit = multiplication % 10;
                tempDigit = multiplication / 10;

                sb.Insert(0, lastDigit);
            }

            if (tempDigit > 0)
            {
                sb.Insert(0, tempDigit);
            }

            Console.WriteLine(sb.ToString());

        }
    }
}

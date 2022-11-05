using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] input = Console.ReadLine().ToCharArray();

            List<char> charInput = input.ToList();
            int power = 0;
            for (int i = 0; i < charInput.Count; i++)
            {
                if (charInput[i] == '>')
                {
                    power += (int)char.GetNumericValue(charInput[i + 1]) - 1;
                    charInput.RemoveAt(i + 1);
                }
                else
                {
                    if (power > 0)
                    {
                        charInput.RemoveAt(i);
                        power--;
                        i--;
                    }
                }
            }

            Console.WriteLine(string.Join("", charInput));

        }
    }
}

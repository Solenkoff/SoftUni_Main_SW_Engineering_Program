using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_Pokemon_Don_t_Go_
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> pockemons = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse).ToList();

            int summedValue = 0;

            while (pockemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int power = 0;


                if (index < 0)
                {
                    index = 0;
                    power = pockemons[0];
                    summedValue += power;
                    pockemons[0] = pockemons[pockemons.Count - 1];

                }
                else if (index > pockemons.Count - 1)
                {
                    index = pockemons.Count - 1;
                    power = pockemons[pockemons.Count - 1];
                    summedValue += power;
                    pockemons[pockemons.Count - 1] = pockemons[0];
                }
                else
                {
                    power = pockemons[index];
                    summedValue += power;
                    pockemons.RemoveAt(index);
                }

                for (int i = 0; i < pockemons.Count; i++)
                {
                    if (pockemons[i] <= power)
                    {
                        pockemons[i] += power;
                    }
                    else if (pockemons[i] > power)
                    {
                        pockemons[i] -= power;
                    }
                }
            }

            Console.WriteLine(summedValue);

        }
    }
}

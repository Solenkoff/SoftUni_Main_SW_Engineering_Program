using System;

namespace _01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int nVagons = int.Parse(Console.ReadLine());
            int[] personsPerVagon = new int[nVagons];
            int personsTotal = 0;
            for (int i = 0; i < nVagons; i++)
            {
                personsPerVagon[i] = int.Parse(Console.ReadLine());
                personsTotal += personsPerVagon[i];
            }
            Console.WriteLine(string.Join(" ", personsPerVagon));
            Console.WriteLine(personsTotal);
        }
    }
}

using System;

namespace _03_Elevator
{
    class Program
    {
        static void Main(string[] args)
        {

            int nPersons = int.Parse(Console.ReadLine());
            int pCapacity = int.Parse(Console.ReadLine());

            int nRuns = 0;
            if (nPersons % pCapacity == 0)
            {
                nRuns = nPersons / pCapacity;         //  while (nPersons > 0)
            }                                         //  {
            else                                      //      nPersons -= pCapacity;
            {                                         //      nRuns++;
                nRuns = nPersons / pCapacity + 1;     //  }
            }
            Console.WriteLine(nRuns);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {

            int nPetrolPumps = int.Parse(Console.ReadLine());

            var petrol = new Queue<int>();
            var distance = new Queue<int>();
            var stationIndex = new Queue<int>();

            for (int i = 0; i < nPetrolPumps; i++)
            {
                int[] data = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                petrol.Enqueue(data[0]);
                distance.Enqueue(data[1]);
                stationIndex.Enqueue(i);
               
            }

            int counter = 0;
            int currPertol = 0;
            
            while (counter < nPetrolPumps)
            {
                int newPetrol = petrol.Dequeue();
                petrol.Enqueue(newPetrol);
                currPertol += newPetrol;
                int currDistance = distance.Dequeue();
                distance.Enqueue(currDistance);
                stationIndex.Enqueue(stationIndex.Dequeue());

                if (currPertol < currDistance)
                {
                    counter = 0;
                    currPertol = 0;
                }
                else
                {
                    counter++;
                    currPertol -= currDistance;
                }
            }

            Console.WriteLine(stationIndex.Dequeue());

        }
    }
}

using System;

namespace _01_Bakery
{
    class Program
    {
        static void Main(string[] args)
        {

            int bisquitsPerWorker = int.Parse(Console.ReadLine());
            int nWorkers = int.Parse(Console.ReadLine());
            int competitorsTotal = int.Parse(Console.ReadLine());

            int bisquits3thDay = (int)Math.Floor(nWorkers * bisquitsPerWorker * 0.75) * 10;
            int factoryTotal = nWorkers * bisquitsPerWorker * 20 + bisquits3thDay;

            Console.WriteLine($"You have produced {factoryTotal} biscuits for the past month.");

            if (factoryTotal > competitorsTotal)
            {
                double difference = 1.0 * (factoryTotal - competitorsTotal) / competitorsTotal * 100;
                Console.WriteLine($"You produce {difference:f2} percent more biscuits.");
            }
            else if (competitorsTotal > factoryTotal)
            {
                double difference = 1.0 * (competitorsTotal - factoryTotal) / competitorsTotal * 100;
                Console.WriteLine($"You produce {difference:f2} percent less biscuits.");
            }

        }
    }
}

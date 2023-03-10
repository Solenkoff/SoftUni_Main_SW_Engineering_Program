using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_Crossroads_
{
    class Program
    {
        static void Main(string[] args)
        {

            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();

            int counter = 0;

            while (true)
            {
                string car = Console.ReadLine();

                int greenSec = greenLightSeconds;
                int windowSec = freeWindowSeconds;

                if (car == "END")
                {
                    Console.WriteLine($"Everyone is safe.{Environment.NewLine}" +
                        $"{counter} total cars passed the crossroads.");
                    return;
                }
                else if (car == "green")
                {
                    while (greenSec > 0 && carsQueue.Count != 0)
                    {

                        string firstInQueue = carsQueue.Dequeue();
                        greenSec -= firstInQueue.Count();
                        if (greenSec >= 0)
                        {
                            counter++;
                        }
                        else
                        {
                            windowSec += greenSec;
                            if (windowSec < 0)
                            {
                                Console.WriteLine($"A crash happened!{Environment.NewLine}" +
                                    $"{firstInQueue} was hit at" +
                                    $" {firstInQueue[firstInQueue.Length + windowSec]}.");
                                return;
                            }
                            counter++;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(car);
                }
            }
        }
    }
}

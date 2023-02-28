using System;
using System.Collections.Generic;

namespace _07_Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] kidsNames = Console.ReadLine().Split();
            int tosses = int.Parse(Console.ReadLine());

            var kids = new Queue<string>(kidsNames);
            int tossesCounter = 1;
            while (kids.Count > 1)
            {
               
                if (tossesCounter == tosses)
                {
                    Console.WriteLine($"Removed {kids.Dequeue()}"); 
                    tossesCounter = 1;
                }
                else
                {
                    string kid = kids.Dequeue();
                    kids.Enqueue(kid);
                    tossesCounter++;
                }
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");

        }
    }
}

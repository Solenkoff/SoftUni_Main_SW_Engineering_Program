using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Birthday_Celebration
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] inputGuests = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] inputPlates = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> guests = new Stack<int>(inputGuests.Reverse());
            Stack<int> plates = new Stack<int>(inputPlates);



            int wastedFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {

                int eating = guests.Pop();
                int food = plates.Pop();


                if (food >= eating)
                {
                    wastedFood += (food - eating);

                }
                else
                {
                    guests.Push(eating - food);
                }





            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: " + string.Join(" ", guests));
            }
            else if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: " + string.Join(" ", plates));
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}

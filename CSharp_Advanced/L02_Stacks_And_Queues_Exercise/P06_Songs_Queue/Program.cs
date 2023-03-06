using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var songs = new Queue<string>(input);

            while (songs.Any())
            {
                string songsInput = Console.ReadLine();
                string[] commands = songsInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Add")
                {            
                    string song = songsInput.Substring(4);

                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
               
            }

            Console.WriteLine("No more songs!");

        }
    }
}

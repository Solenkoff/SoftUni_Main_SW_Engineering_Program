using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_House_Party
{
    class Program
    {
        static void Main(string[] args)
        {

            int numComands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < numComands; i++)
            {
                string[] comands = Console.ReadLine()
                                          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();
                string name = comands[0];
                if (comands.Length == 3)                //(comands[1] == "is" && comands[2] == "going")
                {

                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else if (comands.Length > 3)      //(comands[1] == "is" &&
                                                  // comands[2] == "not" &&
                                                  // comands[3] == "going")
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, guests));
            //for (int i = 0; i < guests.Count; i++)  
            //{                                       
            //    Console.WriteLine(guests[i]);       
            //} 

        }
    }
}

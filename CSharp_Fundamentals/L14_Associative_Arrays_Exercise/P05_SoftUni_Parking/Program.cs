using System;
using System.Collections.Generic;

namespace _05_SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {

            int parkingCount = int.Parse(Console.ReadLine());

            Dictionary<string, string> output = new Dictionary<string, string>();

            for (int i = 0; i < parkingCount; i++)
            {
                string[] commands = Console.ReadLine()
                                          .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string userName = commands[1];


                if (command == "register")
                {
                    string licensePlateNumber = commands[2];

                    if (output.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {output[userName]}");
                    }
                    else
                    {
                        output.Add(userName, licensePlateNumber);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    if (output.ContainsKey(userName))
                    {
                        Console.WriteLine($"{userName} unregistered successfully");
                        output.Remove(userName);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }

            }

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

        }
    }
}

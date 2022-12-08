using System;
using System.Linq;

namespace P01_Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] commandsInput = input.Split(">>>").ToArray();

                if(commandsInput[0] == "Contains")
                {
                    string substring = commandsInput[1];
                    if(rawActivationKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawActivationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if(commandsInput[0] == "Flip")
                {
                    string upperOrLower = commandsInput[1];
                    int startIndex = int.Parse(commandsInput[2]);
                    int endIndex = int.Parse(commandsInput[3]);

                    string toReplace = rawActivationKey.Substring(startIndex, endIndex - startIndex);
                    string replacement = string.Empty;

                    if(upperOrLower == "Upper")
                    {
                        replacement = toReplace.ToUpper();
                    }
                    else if(upperOrLower == "Lower")
                    {
                        replacement = toReplace.ToLower();
                    }

                    rawActivationKey = rawActivationKey.Replace(toReplace, replacement);

                    Console.WriteLine(rawActivationKey);
                }
                else if(commandsInput[0] == "Slice")
                {
                    int startIndex = int.Parse(commandsInput[1]);
                    int endIndex = int.Parse(commandsInput[2]);

                    rawActivationKey = rawActivationKey.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(rawActivationKey);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");

        }
    }
}

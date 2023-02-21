using System;

namespace _01_Problem_City_Demons
{
    class Program
    {
        static void Main(string[] args)
        {

            string skill = Console.ReadLine();


            string input = Console.ReadLine();

            while (input != "For Azeroth")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "GladiatorStance")
                {
                    skill = skill.ToUpper();
                    Console.WriteLine(skill);
                }
                else if (command == "DefensiveStance")
                {
                    skill = skill.ToLower();
                    Console.WriteLine(skill);
                }
                else if (command == "Dispel")
                {
                    int index = int.Parse(commands[1]);
                    string letter = commands[2];

                    if (index >= 0 && index < skill.Length)
                    {
                        skill = skill.Remove(index, 1);
                        skill = skill.Insert(index, letter);
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }

                }
                else if (command == "Target" && commands[1] == "Change")
                {

                    string toReplace = commands[2];
                    string replacement = commands[3];

                    skill = skill.Replace(toReplace, replacement);
                    Console.WriteLine(skill);

                }
                else if (command == "Target" && commands[1] == "Remove")
                {
                    string subString = commands[2];
                    int index = skill.IndexOf(subString);
                    int length = subString.Length;
                    skill = skill.Remove(index, length);
                    Console.WriteLine(skill);
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }

                input = Console.ReadLine();

            }

        }
    }
}

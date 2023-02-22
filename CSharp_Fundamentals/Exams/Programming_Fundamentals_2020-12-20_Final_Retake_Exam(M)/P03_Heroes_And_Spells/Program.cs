using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Problem_Heroes_And_Spells
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();


            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string heroName = commands[1];

                if (command == "Enroll")
                {
                    if (heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                    else
                    {
                        heroes.Add(heroName, new List<string>());
                    }

                }
                if (command == "Learn")
                {
                    string spellName = commands[2];

                    if (heroes.ContainsKey(heroName))
                    {
                        if (heroes[heroName].Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} has already learnt ItShouldWork.");
                        }
                        else
                        {
                            heroes[heroName].Add(spellName);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }
                if (command == "Unlearn")
                {
                    string spellName = commands[2];

                    if (heroes.ContainsKey(heroName))
                    {
                        if (heroes[heroName].Contains(spellName))
                        {
                            heroes[heroName].Remove(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }

                input = Console.ReadLine();
            }


            Console.WriteLine("Heroes:");

            foreach (var hero in heroes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {


                string listOfSpells = string.Join(", ", hero.Value.ToArray());


                Console.WriteLine($"== {hero.Key}: {listOfSpells}");
            }

        }
    }
}

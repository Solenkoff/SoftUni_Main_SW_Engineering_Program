using System;
using System.Collections.Generic;
using System.Linq;

namespace P03v2_P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> cities = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Sail")
            {
                string[] cityInput = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string inputName = cityInput[0];
                int inputPopulation = int.Parse(cityInput[1]);
                int inputGold = int.Parse(cityInput[2]);

                if (cities.ContainsKey(inputName))
                {
                    cities[inputName]["Population"] += inputPopulation;
                    cities[inputName]["Gold"] += inputGold;
                }
                else
                {           
                    cities.Add(inputName, new Dictionary<string, int>
                    {
                        {"Population", inputPopulation },
                        {"Gold", inputGold }
                    });
                }

                input = Console.ReadLine();
            }

            string eventInput = Console.ReadLine();

            while (eventInput != "End")
            {
                string[] eventData = eventInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string currEvent = eventData[0];

                if (currEvent == "Plunder")
                {
                    string town = eventData[1];
                    int people = int.Parse(eventData[2]);
                    int gold = int.Parse(eventData[3]);

                    cities[town]["Population"] -= people;
                    cities[town]["Gold"] -= gold;
                
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (cities[town]["Gold"] == 0 || cities[town]["Population"] == 0)
                    {
                        cities.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }

                }
                else if (currEvent == "Prosper")
                {
                    string town = eventData[1];
                    int gold = int.Parse(eventData[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[town]["Gold"] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town]["Gold"]} gold.");
                    }
                }

                eventInput = Console.ReadLine();
            }


            if (cities.Any())
            {

                Dictionary<string, Dictionary<string, int>> sortedCities = cities.OrderByDescending(x => x.Value["Gold"])
                                                                                 .ThenBy(x => x.Key)
                                                                                 .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"Ahoy, Captain! There are {sortedCities.Count} wealthy settlements to go to:");
                foreach (var city in sortedCities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value["Population"]} citizens, Gold: {city.Value["Gold"]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }
}

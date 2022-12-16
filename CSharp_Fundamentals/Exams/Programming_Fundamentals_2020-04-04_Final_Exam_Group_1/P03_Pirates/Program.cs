using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_P_rates
{
    class Program
    {
        static void Main(string[] args)
        {

            List<City> cities = new List<City>();

            string input = Console.ReadLine(); 

            while (input != "Sail")
            {
                string[] cityInput = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string inputName = cityInput[0];
                int inputPopulation = int.Parse(cityInput[1]);
                int inputGold = int.Parse(cityInput[2]);

                City newCity = new City(inputName, inputPopulation, inputGold);

                City existingCity = cities.FirstOrDefault(x => x.Name == inputName);

                if(existingCity == null)
                {
                    cities.Add(newCity);
                }
                else
                {
                    existingCity.Population += inputPopulation;
                    existingCity.Gold += inputGold; 
                }

                input = Console.ReadLine();
            }

            string eventInput = Console.ReadLine();

            while (eventInput != "End")
            {
                string[] eventData = eventInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string currEvent = eventData[0];

                if(currEvent == "Plunder")
                {
                    string town = eventData[1];
                    int people = int.Parse(eventData[2]);
                    int gold = int.Parse(eventData[3]);
                   
                    City currCity = cities.FirstOrDefault(x => x.Name == town);

                    currCity.Population -= people;
                    currCity.Gold -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (currCity.Gold == 0 || currCity.Population == 0)
                    {
                        cities.Remove(currCity);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }

                }
                else if(currEvent == "Prosper")
                {
                    string town = eventData[1];
                    int gold = int.Parse(eventData[2]);

                    City currCity = cities.FirstOrDefault(x => x.Name == town);

                    if(gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        currCity.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {currCity.Gold} gold.");
                    }
                }

                eventInput = Console.ReadLine();
            }

            if(cities.Any())
            {
                List<City> sortedCities = cities.OrderByDescending(x => x.Gold).ThenBy(x => x.Name).ToList();
                Console.WriteLine($"Ahoy, Captain! There are {sortedCities.Count} wealthy settlements to go to:");
                foreach (var city in sortedCities)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }

    class City
    {

        public City(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

    }

}

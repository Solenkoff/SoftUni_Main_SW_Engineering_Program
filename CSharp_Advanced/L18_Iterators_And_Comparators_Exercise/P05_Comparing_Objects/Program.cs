using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Comparing_Objects
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> listOfPeople = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] personData = input.Split(" ");
                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];

                Person currPerson = new Person(name, age, town);

                listOfPeople.Add(currPerson);

                input = Console.ReadLine();
            }

            int indexToCompareTo = int.Parse(Console.ReadLine()) - 1;
          
            int totalNumPeople = listOfPeople.Count;
            int mathces = 0;
            
           
            foreach (var item in listOfPeople)
            {
                if (item.CompareTo(listOfPeople[indexToCompareTo]) == 0)
                {
                    mathces++;
                }
            }
            
            if (mathces == 1)
            {
                mathces = 0;
            }

            int nonMatches = totalNumPeople - mathces;

            if (mathces == 0 || indexToCompareTo < 0 || indexToCompareTo > listOfPeople.Count - 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{mathces} {nonMatches} {totalNumPeople}");
            }

        }
    }
}

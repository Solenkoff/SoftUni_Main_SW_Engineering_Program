using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> members = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine()
                                             .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person currPerson = new Person(name, age);

                members.Add(currPerson);
                
            }
          
            foreach (var person in members.OrderBy(x => x.Name).Where(x => x.Age > 30))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}

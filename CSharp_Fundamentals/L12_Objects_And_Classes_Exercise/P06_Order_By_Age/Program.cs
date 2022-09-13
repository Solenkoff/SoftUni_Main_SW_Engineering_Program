using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_Order_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> register = new List<Person>().ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] personsData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personsData[0];
                string iD = personsData[1];
                int age = int.Parse(personsData[2]);

                Person currentPerson = new Person(name, iD, age);
                register.Add(currentPerson);


                input = Console.ReadLine();
            }


            StringBuilder sb = new StringBuilder();

            foreach (Person person in register.OrderBy(x => x.Age))
            {
                sb.AppendLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }

            Console.WriteLine(sb.ToString());

        }
    }

    class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

    }

}

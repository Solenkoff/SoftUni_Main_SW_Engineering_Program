﻿using System;

namespace _05_Filter_By_Age
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people[i] = new Person()
                {
                    Name = input[0],
                    Age = int.Parse(input[1])
                };
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> conditionDelegate = GetCondition(condition, ageFilter);
            Action<Person> printDelegate = GetPrinter(format);

            foreach (var person in people)
            {
                if(conditionDelegate(person))
                {
                    printDelegate(person);
                }
            }

        }


        static Action<Person> GetPrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return p =>
                    {
                        Console.WriteLine($"{p.Name}");
                    };
                case "age":
                    return p =>
                    {
                        Console.WriteLine($"{p.Age}");
                    };
                case "name age":
                    return p =>
                    {
                        Console.WriteLine($"{p.Name} - {p.Age}");
                    };

                default: return null;                   
            }      
        }

        static Func<Person, bool> GetCondition(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return p => p.Age < age;
                case "older": return p => p.Age >= age;

                default: return null;
            }
        }

    }
}

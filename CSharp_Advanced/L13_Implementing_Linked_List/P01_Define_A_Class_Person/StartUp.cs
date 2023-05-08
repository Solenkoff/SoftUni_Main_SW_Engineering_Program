using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var person = new Person("Pesho", 18);
       
            Console.WriteLine($"{person.Name} - {person.Age}");

        }
    }
}

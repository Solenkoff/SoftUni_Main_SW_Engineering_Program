using System;

namespace Person
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            //Person person = new Person("Pesho", 13);

            //Console.WriteLine(person);

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new Child(name, age);
            Console.WriteLine(child);

        }
    }
}

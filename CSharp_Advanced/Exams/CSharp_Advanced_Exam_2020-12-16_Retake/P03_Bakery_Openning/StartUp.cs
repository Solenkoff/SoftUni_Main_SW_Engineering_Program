namespace BakeryOpenning
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            Employee nov = new Employee("Gogo", 20, "Bulgaria");
            Employee nov2 = new Employee("Bobo", 10, "Gana");

            Bakery bake = new Bakery("bake", 3);

            bake.Add(nov);
            bake.Add(nov2);

            bake.Remove(nov2.Name);

            Console.WriteLine(nov);

            Console.WriteLine(bake.Report());

        }
    }
}

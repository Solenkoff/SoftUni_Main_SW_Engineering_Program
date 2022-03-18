using System;

namespace P07_Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int ticketPrice = 0;

            if (age >= 0 && age <= 18)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        ticketPrice = 12;
                        break;
                    case "Weekend":
                        ticketPrice = 15;
                        break;
                    case "Holiday":
                        ticketPrice = 5;
                        break;
                }
            }
            else if (age > 18 && age <= 64)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        ticketPrice = 18;
                        break;
                    case "Weekend":
                        ticketPrice = 20;
                        break;
                    case "Holiday":
                        ticketPrice = 12;
                        break;
                }
            }
            else if (age > 64 && age <= 122)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        ticketPrice = 12;
                        break;
                    case "Weekend":
                        ticketPrice = 15;
                        break;
                    case "Holiday":
                        ticketPrice = 10;
                        break;
                }
            }
            if (ticketPrice == 0)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{ticketPrice}$");
            }
        }
    }
}

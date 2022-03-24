using System;

namespace P03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int nPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double price = 0;

            if (typeOfGroup == "Students")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        price = nPeople * 8.45;
                        break;
                    case "Saturday":
                        price = nPeople * 9.80;
                        break;
                    case "Sunday":
                        price = nPeople * 10.46;
                        break;
                    default:
                        Console.WriteLine("Not a valid date");
                        break;
                }
                if (nPeople >= 30)
                {
                    price *= 0.85;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (nPeople >= 100)
                {
                    nPeople -= 10;
                }
                switch (dayOfWeek)
                {

                    case "Friday":
                        price = nPeople * 10.90;
                        break;
                    case "Saturday":
                        price = nPeople * 15.60;
                        break;
                    case "Sunday":
                        price = nPeople * 16;
                        break;
                    default:
                        Console.WriteLine("Not a valid date");
                        break;
                }
            }
            else if (typeOfGroup == "Regular")
            {
                switch (dayOfWeek)
                {

                    case "Friday":
                        price = nPeople * 15;
                        break;
                    case "Saturday":
                        price = nPeople * 20;
                        break;
                    case "Sunday":
                        price = nPeople * 22.50;
                        break;
                    default:
                        Console.WriteLine("Not a valid date");
                        break;
                }
                if (nPeople >= 10 && nPeople <= 20)
                {
                    price *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}

using System;

namespace _05_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            double amount = 0;
            string accomodation = "";

            switch (season)
            {
                case "summer":
                    if (budget <= 100)
                    {
                        destination = "Bulgaria";
                        amount = budget * 0.30;
                        accomodation = "Camp";
                    }
                    else if (budget <= 1000)
                    {
                        destination = "Balkans";
                        amount = budget * 0.40;
                        accomodation = "Camp";
                    }
                    else if (budget > 1000)
                    {
                        destination = "Europe";
                        amount = budget * 0.90;
                        accomodation = "Hotel";
                    }
                    break;
                case "winter":
                    if (budget <= 100)
                    {
                        destination = "Bulgaria";
                        amount = budget * 0.70;
                        accomodation = "Hotel";
                    }
                    else if (budget <= 1000)
                    {
                        destination = "Balkans";
                        amount = budget * 0.80;
                        accomodation = "Hotel";
                    }
                    else if (budget > 1000)
                    {
                        destination = "Europe";
                        amount = budget * 0.90;
                        accomodation = "Hotel";
                    }
                    break;
            }
            Console.WriteLine($"Somewhere in {destination} ");
            Console.WriteLine($"{accomodation} - {amount:f2}");
        }
    }
}

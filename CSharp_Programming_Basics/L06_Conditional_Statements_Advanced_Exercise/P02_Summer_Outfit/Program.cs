using System;

namespace _02_Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int grade = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            string outfit = "";
            string shoes = "";
            switch (text)
            {
                case "Morning":
                    if (grade >= 10 && grade <= 18)
                    {
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                    }
                    else if (grade > 18 && grade <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (grade >= 25)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    break;
                case "Afternoon":
                    if (grade >= 10 && grade <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (grade > 18 && grade <= 24)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    else if (grade >= 25)
                    {
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    break;
                case "Evening":
                    if (grade >= 10 && grade <= 18 || grade > 18 && grade <= 24 || grade >= 25)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    break;
            }
            Console.WriteLine($"It's {grade} degrees, get your {outfit} and {shoes}.");
        }
    }
}

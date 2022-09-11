using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Vehicle> catalogue = new List<Vehicle>();
            string comand = Console.ReadLine();

            while (comand != "End")
            {
                string[] vehicleData = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = vehicleData[0].ToLower();
                string model = vehicleData[1];
                string color = vehicleData[2].ToLower();
                int hP = int.Parse(vehicleData[3]);

                Vehicle currentVehicle = new Vehicle(type, model, color, hP);
                catalogue.Add(currentVehicle);

                comand = Console.ReadLine();
            }


            string secondComand = Console.ReadLine();
            while (secondComand != "Close the Catalogue")
            {
                string modelType = secondComand;
                Vehicle printCar = catalogue.First(x => x.Model == modelType);

                Console.WriteLine(printCar);

                secondComand = Console.ReadLine();
            }

            List<Vehicle> onlyCars = catalogue.Where(x => x.Type == "car").ToList();
            List<Vehicle> onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();

            double totalCarsHp = onlyCars.Sum(x => x.Horsepower);
            double totalTrucksHp = onlyTrucks.Sum(x => x.Horsepower);

            double avgCarHp = 0.00;
            double avgTruckHp = 0.00;

            if (onlyCars.Count > 0)
            {
                avgCarHp = totalCarsHp / onlyCars.Count;
            }
            if (onlyTrucks.Count > 0)
            {
                avgTruckHp = totalTrucksHp / onlyTrucks.Count;
            }
            Console.WriteLine($"Cars have average horsepower of: {avgCarHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTruckHp:f2}.");

        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {Horsepower}");

            return sb.ToString().TrimEnd();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> listOftires = new List<Tire[]>();
            List<Engine> listOfEngines = new List<Engine>();
            List<Car> listOfCars = new List<Car>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tiresData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] currTires = new Tire[4] 
                {
                     new Tire(int.Parse(tiresData[0]), double.Parse(tiresData[1])),
                     new Tire(int.Parse(tiresData[2]), double.Parse(tiresData[3])),
                     new Tire(int.Parse(tiresData[4]), double.Parse(tiresData[5])),
                     new Tire(int.Parse(tiresData[6]), double.Parse(tiresData[7]))             
                };

                listOftires.Add(currTires);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                                        
                int horsePower = int.Parse(engineData[0]);
                double cubicCapacity = double.Parse(engineData[1]);

                Engine currEngine = new Engine(horsePower, cubicCapacity);
                listOfEngines.Add(currEngine);
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carsData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = carsData[0];
                string model = carsData[1];
                int year = int.Parse(carsData[2]);
                double fuelQuantity = double.Parse(carsData[3]);
                double fuelConsumption = double.Parse(carsData[4]);
                int engineIndex = int.Parse(carsData[5]);
                int tiresIndex = int.Parse(carsData[6]);

                Car currCar = new Car(make, model, year, fuelQuantity, fuelConsumption,
                                            listOfEngines[engineIndex], listOftires[tiresIndex]);
                listOfCars.Add(currCar);
            }
          
            Console.WriteLine(SpecialCars(listOfCars));

        }

        public static string SpecialCars(List<Car> cars)
        {
            List<Car> spcialCars = cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();

            StringBuilder printSpecialCars = new StringBuilder();

            foreach (var car in spcialCars)
            {
                car.Drive(20);
                printSpecialCars.AppendLine($"Make: {car.Make}");
                printSpecialCars.AppendLine($"Model: {car.Model}");
                printSpecialCars.AppendLine($"Year: {car.Year}");
                printSpecialCars.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                printSpecialCars.AppendLine($"FuelQuantity: {car.FuelQuantity}");
            }

            return printSpecialCars.ToString();

        }

    }
}

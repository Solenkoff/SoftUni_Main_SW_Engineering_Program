using System;
using System.Collections.Generic;
using System.Linq;

namespace _06v2_Speed_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();


            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionFor1km = double.Parse(carData[2]);

                Car currCar = new Car
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumptionFor1km
                
                };

                cars.Add(currCar);

            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = commands[1];
                double distanceTraveled = double.Parse(commands[2]);

                Car car = cars.FirstOrDefault(c => c.Model == model);

                bool isDrive = car.Drive(distanceTraveled);

                if(isDrive == false)
                {
                    Console.WriteLine("Insufficient fuel for the drive") ;
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }

        }
    }
}

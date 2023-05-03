using System;
using System.Collections.Generic;

namespace _06_Speed_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {

            int nCars = int.Parse(Console.ReadLine());

            Dictionary<string, Car> listOfCars = new Dictionary<string, Car>();

            for (int i = 0; i < nCars; i++)
            {
                string[] carData = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double TravelledDistance = double.Parse(carData[2]);

                Car currCar = new Car(model, fuelAmount, TravelledDistance, 0);

                listOfCars.Add(model, currCar);

            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = commands[1];
                double amountOfKm = double.Parse(commands[2]);

                if (Car.DistanceCovoringPossibility(listOfCars[carModel], amountOfKm))
                {
                    double usedFuel = listOfCars[carModel].FuelPerKm * amountOfKm;
                    listOfCars[carModel].TravelledDistance += amountOfKm;
                    listOfCars[carModel].FuelAmount -= usedFuel;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                
                input = Console.ReadLine();
            }

            foreach (var car in listOfCars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.TravelledDistance}");
            }

        }
    }
}

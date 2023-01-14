using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Need_For_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberCars; i++)
            {
                string[] carData = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                string carName = carData[0];
                int mileage = int.Parse(carData[1]);
                int fuel = int.Parse(carData[2]);

                Car newCar = new Car(carName, mileage, fuel);

                cars.Add(newCar);
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] parts = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string carName = parts[1];

                Car currCar = cars.FirstOrDefault(x => x.Name == carName);

                if (command == "Drive")
                {
                    int distance = int.Parse(parts[2]);
                    int fuelNeeded = int.Parse(parts[3]);
                 
                    int carFuel = currCar.Fuel;

                    if(carFuel < fuelNeeded)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        currCar.Mileage += distance;
                        currCar.Fuel -= fuelNeeded;
                        Console.WriteLine($"{currCar.Name} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                    }

                    if(currCar.Mileage >= 100000)
                    {                   
                        Console.WriteLine($"Time to sell the {currCar.Name}!");
                        cars.Remove(currCar);
                    }

                }
                else if (command == "Refuel")
                {
                    int fuelGiven = int.Parse(parts[2]);
                    int fuelRefilled = 0;
                    if(currCar.Fuel + fuelGiven >= 75)
                    {                     
                        fuelRefilled = 75 - currCar.Fuel;
                        currCar.Fuel = 75;
                    }
                    else
                    {
                        currCar.Fuel += fuelGiven;
                        fuelRefilled = fuelGiven;
                    }

                    Console.WriteLine($"{currCar.Name} refueled with {fuelRefilled} liters");

                }
                else if (command == "Revert")
                {
                    int kilomiters = int.Parse(parts[2]);

                    if(currCar.Mileage - kilomiters < 10000)
                    {
                        currCar.Mileage = 10000;
                    }
                    else
                    {
                        currCar.Mileage -= kilomiters;
                        Console.WriteLine($"{currCar.Name} mileage decreased by {kilomiters} kilometers");
                    }
                   
                }

                input = Console.ReadLine();
            }

            List<Car> sortedCars = cars.OrderByDescending(x => x.Mileage).ThenBy(x => x.Name).ToList();

            foreach (var car in sortedCars)
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }


    class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            this.Name = name;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public string Name { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }

    }

}

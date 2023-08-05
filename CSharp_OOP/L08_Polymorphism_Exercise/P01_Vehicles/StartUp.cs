using System;

namespace P01v2_Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] parts = Console.ReadLine().Split();
                string command = parts[0];
                string vehicleType = parts[1];
                double parameter = double.Parse(parts[2]);

                if (command == "Drive")
                {
                    try
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Drive(parameter);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Drive(parameter);
                        }

                        Console.WriteLine($"{vehicleType} travelled {parameter} km");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    if (vehicleType == nameof(Car))
                    {
                        car.Refuel(parameter);
                    }
                    else if (vehicleType == nameof(Truck))
                    {
                        truck.Refuel(parameter);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);

        }



        private static Vehicle CreateVehicle()
        {

            string[] parts = Console.ReadLine().Split();

            string type = parts[0];
            double fuelQuantity = double.Parse(parts[1]);
            double fuelConsomption = double.Parse(parts[2]);

            Vehicle vehicle = null;

            if(type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsomption);
            }
            else if(type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsomption);
            }

            return vehicle;

        }
    }
}

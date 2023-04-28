using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car bmv = new Car("BMW", "X6", 1993, 5003, -50);
            Car defaultGolf = new Car();
            Console.WriteLine($"Default Golf: " + defaultGolf.WhoAmI());

            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;

            car.Drive(0.5);

            Car v12 = new Car();

            v12.Make = "v12";
            v12.Model = "100km/h";
            v12.Year = 2025;
            v12.FuelQuantity = 2000000;
            v12.FuelConsumption = 0;
            v12.Drive(0.5);

            Console.WriteLine(v12.WhoAmI());
            Console.WriteLine(car.WhoAmI());

        }
    }
}

using System;
using System.Collections.Generic;


namespace _07_Raw_Data
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
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];
                
                Tire[] currTires = new Tire[4]
               {
                     new Tire(double.Parse(carData[5]), int.Parse(carData[6])),
                     new Tire(double.Parse(carData[7]), int.Parse(carData[8])),
                     new Tire(double.Parse(carData[9]), int.Parse(carData[10])),
                     new Tire(double.Parse(carData[11]), int.Parse(carData[12]))
               };

                Engine currEngine = new Engine(engineSpeed, enginePower);

                Cargo currCargo = new Cargo(cargoWeight, cargoType);

                Car currCar = new Car(model, currEngine, currCargo, currTires);

                cars.Add(currCar);
            }

            string input = Console.ReadLine();

            if (input == "fragile")
            {
                Car.PrintFragile(cars);
            }
            else if (input == "flamable")
            {
                Car.PrintFlamable(cars);
            }

        }    
    }
}

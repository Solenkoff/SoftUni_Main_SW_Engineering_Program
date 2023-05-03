using System;
using System.Collections.Generic;
using System.Linq;


namespace _07_Raw_Data
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires{ get; set; }



        public static void PrintFragile(List<Car> cars)
        {
            List<Car> sortedCars = cars.Where(x => x.Cargo.CargoType == "fragile")
                                       .Where(x => x.Tires.Any(y => y.TirePressure < 1))
                                       .ToList();

            foreach (var car in sortedCars)
            {
                Console.WriteLine(car.Model);
            }
        }

        public static void PrintFlamable(List<Car> cars)
        {
            List<Car> sortedCars = cars.Where(x => x.Cargo.CargoType == "flamable")
                                       .Where(x => x.Engine.EnginePower > 250)
                                       .ToList();

            foreach (var car in sortedCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }

}

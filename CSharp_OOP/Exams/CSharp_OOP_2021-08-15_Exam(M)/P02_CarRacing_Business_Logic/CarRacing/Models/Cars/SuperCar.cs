﻿namespace CarRacing.Models.Cars
{

    public class SuperCar : Car
    {
        private const double InitialFuelAvailable = 80;
        private const double DefaultfuelConsumptionPerRace = 10;
        public SuperCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, InitialFuelAvailable, DefaultfuelConsumptionPerRace)
        {
        }

    }
}

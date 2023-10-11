namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SuperCar : Car
    {
        private const double InitialFuelAvailable = 80;
        private const double InitialfuelConsumptionPerRace = 10;
        public SuperCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, InitialFuelAvailable, InitialfuelConsumptionPerRace)
        {
        }

    }
}

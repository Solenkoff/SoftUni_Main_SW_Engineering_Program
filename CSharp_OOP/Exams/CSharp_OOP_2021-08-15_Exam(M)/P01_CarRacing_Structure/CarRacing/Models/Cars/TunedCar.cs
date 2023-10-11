namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TunedCar : Car
    {
        private const double InitialFuelAvailable = 65;
        private const double InitialfuelConsumptionPerRace = 7.5;
        public TunedCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, InitialFuelAvailable, InitialfuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower = Convert.ToInt32(this.HorsePower * 0.97);
        }
    }
}

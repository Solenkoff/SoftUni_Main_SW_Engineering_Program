namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double InitialFuelAvailable = 65;
        private const double DefaultfuelConsumptionPerRace = 7.5;
        public TunedCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, InitialFuelAvailable, DefaultfuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower = (int)Math.Round(this.HorsePower * 0.97);
        }
    }
}

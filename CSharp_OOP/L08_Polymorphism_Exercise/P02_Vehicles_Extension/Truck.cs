using System;
using System.Collections.Generic;
using System.Text;

namespace P01v2_Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
             : base(fuelQuantity, fuelConsumption, tankCapacity, TruckAirConditionModifier)
        {

        }


        public override void Refuel(double refuelQuantiy)
        {
            
            if (refuelQuantiy <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + refuelQuantiy > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {refuelQuantiy} fuel in the tank");
            }

            this.FuelQuantity += refuelQuantiy * 0.95;
        }
    }
}

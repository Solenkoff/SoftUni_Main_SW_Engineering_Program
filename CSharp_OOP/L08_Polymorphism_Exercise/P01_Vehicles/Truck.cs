using System;
using System.Collections.Generic;
using System.Text;

namespace P01v2_Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption, TruckAirConditionModifier)
        {

        }


        public override void Refuel(double refuelQuantiy)
        {
            base.Refuel(refuelQuantiy * 0.95);
        }
    }
}

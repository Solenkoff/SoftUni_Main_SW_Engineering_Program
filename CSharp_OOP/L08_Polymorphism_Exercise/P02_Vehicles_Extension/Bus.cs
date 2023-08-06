using System;
using System.Collections.Generic;
using System.Text;

namespace P01v2_Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionModifier = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, BusAirConditionModifier)
        {

        }

        public void AirConditionOn()
        {
            this.AirConditionModifier = BusAirConditionModifier;
        }

        public void AirConditionOff()
        {
            this.AirConditionModifier = 0;
        }

    }
}

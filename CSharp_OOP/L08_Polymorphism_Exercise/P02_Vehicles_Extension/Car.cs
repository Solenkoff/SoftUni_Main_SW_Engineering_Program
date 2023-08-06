using System;
using System.Collections.Generic;
using System.Text;

namespace P01v2_Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirConditionModifier = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, CarAirConditionModifier)
        {
            
        }


    }
}

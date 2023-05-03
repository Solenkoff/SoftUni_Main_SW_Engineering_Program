using System;
using System.Collections.Generic;
using System.Text;

namespace _06v2_Speed_Racing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public bool Drive(double distanceTraveled)
        {
            double neededFuel = this.FuelConsumptionPerKilometer * distanceTraveled;

            if(neededFuel > this.FuelAmount)
            {
                return false;
            }

            this.FuelAmount -= neededFuel;
            this.TravelledDistance += distanceTraveled;

            return true;
        }
    }
}

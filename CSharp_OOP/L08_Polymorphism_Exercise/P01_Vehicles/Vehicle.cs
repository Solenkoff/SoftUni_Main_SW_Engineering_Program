using System;
using System.Collections.Generic;
using System.Text;

namespace P01v2_Vehicles
{
    public abstract class Vehicle
    {

        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionModifier)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionModifier = airConditionModifier;
        }


        private double AirConditionModifier { get; set; }
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public void Drive(double distance)
        {
            double requiredFuel = distance * (this.FuelConsumption + this.AirConditionModifier);

            if (requiredFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= requiredFuel;
            
        }

        public virtual void Refuel(double refuelQuantiy)
        {
            this.FuelQuantity += refuelQuantiy;
        }


        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}"; 
        }
    }
}

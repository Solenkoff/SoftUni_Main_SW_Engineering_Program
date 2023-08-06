using System;
using System.Collections.Generic;
using System.Text;

namespace P01v2_Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double airConditionModifier)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            
            this.AirConditionModifier = airConditionModifier;            
        }


        protected double AirConditionModifier { get; set; }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if(value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

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
            if (refuelQuantiy <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + refuelQuantiy > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {refuelQuantiy} fuel in the tank");
            }

            this.FuelQuantity += refuelQuantiy;
        }


        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}"; 
        }
    }
}

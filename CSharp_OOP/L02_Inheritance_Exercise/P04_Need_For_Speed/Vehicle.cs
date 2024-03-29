﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }
        
        public virtual double FuelConsumption => DefaultFuelConsumption;


        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }


        public override string ToString()
        {
            return $"Type: {this.GetType().Name} HorsePower: {this.HorsePower} Fuel: {this.Fuel}";
        }

    }
}

﻿

namespace _07_Raw_Data
{
    public class Tire
    {

        public Tire(double tirePressure, int tireAge)
        {
            this.TirePressure = tirePressure;
            this.TireAge = tireAge;
        }

        public double TirePressure { get; set; }

        public int TireAge { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _03_The_Race
{
    public class Car
    {
        public Car(string name, int speed)
        {
            this.Name = name;
            this.Speed = speed;
        }

        public string Name { get; set; }

        public int Speed { get; set; }

    }
}

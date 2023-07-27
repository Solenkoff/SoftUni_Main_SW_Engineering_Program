using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string name;
        private int weight;


        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                var valueToLower = value.ToLower();
                if (valueToLower != "meat" &&
                   valueToLower != "veggies" &&
                   valueToLower != "cheese" &&
                   valueToLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.name = value;
            }
        }


        public int Weight
        {
            get => this.weight;
            set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value,
                    $"{this.Name} weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }
        }


        public double GetCalories()
        {
            var modifier = GetModifier();

            return this.Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            var nameToLower = this.Name.ToLower();

            if (nameToLower == "meat")
            {
                return 1.2;
            }

            if (nameToLower == "veggies")
            {
                return 0.8;
            }

            if (nameToLower == "cheese")
            {
                return 1.1;
            }

            return 0.9;

        }
    }
}

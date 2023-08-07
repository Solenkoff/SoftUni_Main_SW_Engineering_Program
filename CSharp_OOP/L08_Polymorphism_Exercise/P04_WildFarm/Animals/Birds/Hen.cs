using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    class Hen : Bird
    {

        private const double BaseWeightModifier = 0.35;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Meat),
            nameof(Seeds)
        };
        public Hen(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, allowedFoods, BaseWeightModifier, wingSize)
        {

        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

    }
}

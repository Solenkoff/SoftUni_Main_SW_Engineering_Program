using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {

        private const double BaseWeightModifier = 0.10;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit)
        };
      
        public Mouse(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, allowedFoods, BaseWeightModifier, livingRegion)
        {
            
                
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

    }
}

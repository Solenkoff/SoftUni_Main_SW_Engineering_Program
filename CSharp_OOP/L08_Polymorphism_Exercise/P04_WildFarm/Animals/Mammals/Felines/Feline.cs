using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name,
                         double weight,
                         int foodEaten,
                         HashSet<string> allowedFoods,
                         double weightModifier,
                         string livingRegion,
                         string breed)
            : base(name, weight, foodEaten, allowedFoods, weightModifier, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }


        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

    }
}

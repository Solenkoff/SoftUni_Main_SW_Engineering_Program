using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {


        private List<Ingredient> Ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);


        public void Add(Ingredient ingredient)
        {
            Ingredient currIngr = this.Ingredients.FirstOrDefault(x => x.Name == ingredient.Name);
            if (this.Ingredients.Count < this.Capacity && currIngr == null)
            {
                this.Ingredients.Add(ingredient);
            }
        }



        public bool Remove(string name)
        {
            Ingredient currIngr = this.Ingredients.FirstOrDefault(x => x.Name == name);

            if(currIngr == null)
            {
                return false;
            }

            this.Ingredients.Remove(currIngr);

            return true;
        }


        public Ingredient FindIngredient(string name)
        {
            Ingredient currIngr = this.Ingredients.FirstOrDefault(x => x.Name == name);

            return currIngr;
        }


        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var ingr in this.Ingredients)
            {
                sb.AppendLine(ingr.ToString());
            }

            return sb.ToString().Trim();
        }







    }

}

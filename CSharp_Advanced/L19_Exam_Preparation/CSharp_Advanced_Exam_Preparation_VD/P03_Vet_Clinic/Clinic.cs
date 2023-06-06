using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private readonly List<Pet> pets;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            this.pets = new List<Pet>();
        }


        public int Capacity { get; set; }

        public int Count => this.pets.Count();

        public void Add(Pet pet)
        {
            if (this.pets.Count < this.Capacity)
            {
                this.pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet searchedPet = this.pets.FirstOrDefault(x => x.Name == name);
            if (searchedPet != null)
            {
                this.pets.Remove(searchedPet);
                return true;
            }
            else
            {
                return false;
            }
        }


        public Pet GetPet(string name, string owner)
        {
            Pet searchedPet = this.pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);

            return searchedPet;
        }

        public Pet GetOldestPet()
        {
            Pet aldestPet = this.pets.OrderByDescending(x => x.Age).FirstOrDefault();

            return aldestPet;

        }


        public string GetStatistics()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");

            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().Trim();
        }

    }
}

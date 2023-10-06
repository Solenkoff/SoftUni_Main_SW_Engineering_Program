namespace AquaShop.Models.Aquariums
{
    using Utilities;
    using Models.Aquariums.Contracts;
    using Models.Decorations.Contracts;
    using Models.Fish.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Utilities.Messages;
    using System.Linq;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private string capacity;
        private int comfort;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, ExceptionMessages.InvalidAquariumName);

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.AsReadOnly();

        public ICollection<IFish> Fish => this.fish.AsReadOnly();


        public void AddFish(IFish fish)
        {
            if(this.Capacity == this.fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }


        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }
     

        public void Feed()
        {
            foreach (var fishItem in fish)
            {
                fishItem.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if(this.fish.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.fish)}");
            }

            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().Trim();
        }
            

    }
}

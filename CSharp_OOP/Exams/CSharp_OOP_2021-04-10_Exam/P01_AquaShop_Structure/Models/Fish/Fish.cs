﻿namespace AquaShop.Models.Fish
{
    using Utilities;
    using Utilities.Messages;
    using Models.Fish.Contracts;
    using System;


    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private int size;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, ExceptionMessages.InvalidFishName);
   
                this.name = value;
            }
        }

        public string Species
        {
            get => this.species;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, ExceptionMessages.InvalidFishSpecies);

                this.species = value;
            }
        }

        public int Size { get; protected set; }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }

                this.price = value;
            }
        }

        public abstract void Eat();
        
    }
}

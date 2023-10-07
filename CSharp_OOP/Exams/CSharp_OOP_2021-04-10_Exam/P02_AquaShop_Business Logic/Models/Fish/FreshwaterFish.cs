﻿namespace AquaShop.Models.Fish
{
    
    public class FreshwaterFish : Fish
    {
        private const int SizeIncrement = 3;
        private const int InitialSize = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = InitialSize;
        }

     
        public override void Eat()
        {
            this.Size += SizeIncrement;
        }

    }
}

namespace AquaShop.Models.Decorations
{
    using Models.Decorations.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Decoration : IDecoration
    {
        protected Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }

        public int Comfort { get; private set; }

        public decimal Price { get; private set; }
    }
}

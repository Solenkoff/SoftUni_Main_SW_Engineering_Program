namespace AquaShop.Models.Decorations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Ornament : Decoration
    {
        private const int OrnamentComfort = 1;
        private const decimal OrnamentPrice = 5;
        public Ornament() 
            : base(OrnamentComfort, OrnamentPrice)
        {

        }
    }
}

namespace AquaShop.Models.Decorations.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Plant : Decoration
    {
        private const int PlantComfort = 5;
        private const decimal PlantPrice = 10;
        public Plant() 
            : base(PlantComfort, PlantPrice)
        {
        }
    }
}

﻿namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HappyBunny : Bunny
    {
        private const int INITIAL_ENERGY = 100;

        public HappyBunny(string name)
            : base(name, INITIAL_ENERGY)
        {
        }
    }
}

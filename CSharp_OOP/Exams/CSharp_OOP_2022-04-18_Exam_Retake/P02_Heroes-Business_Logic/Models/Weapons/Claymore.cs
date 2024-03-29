﻿namespace Heroes.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Claymore : Weapon
    {
        private const int CalymoreDamage = 20;

        public Claymore(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {     

            if (this.Durability == 0)
            {
                return 0;
            }

            this.Durability--;

            return CalymoreDamage;
        }

    }
}

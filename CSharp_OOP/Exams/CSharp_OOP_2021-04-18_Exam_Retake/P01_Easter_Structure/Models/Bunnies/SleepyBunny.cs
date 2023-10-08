namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SleepyBunny : Bunny
    {
        private const int INITIAL_ENERGY = 50;
        public SleepyBunny(string name) 
            : base(name, INITIAL_ENERGY)
        {
        }

        public override void Work()
        {
            this.Energy -= 15;

            if(this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}

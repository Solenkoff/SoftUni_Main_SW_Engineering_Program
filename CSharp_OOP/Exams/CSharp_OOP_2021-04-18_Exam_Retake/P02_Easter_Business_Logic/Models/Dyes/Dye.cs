namespace Easter.Models.Dyes
{
    using Easter.Models.Dyes.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Dye : IDye
    {
        private const int DEFAULT_POWER_DECREASE = 10;

        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => power;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                power = value;
            }
        }

        public bool IsFinished() => this.Power == 0;


        public void Use() => this.Power -= DEFAULT_POWER_DECREASE;
        
    }
}

namespace Easter.Models.Eggs
{
    using Easter.Models.Eggs.Contracts;
    using Easter.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Egg : IEgg
    {
        private const int DEFAULT_UNIT_DECRESE = 10;

        private string name;
        private int energyRequired;


        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => energyRequired;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                energyRequired = value;
            }
        }

        public void GetColored() 
            => this.EnergyRequired -= DEFAULT_UNIT_DECRESE;
        

        public bool IsDone() => this.EnergyRequired == 0;
        
    }
}

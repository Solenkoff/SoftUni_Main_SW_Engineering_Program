namespace Easter.Models.Eggs
{
    using Easter.Models.Eggs.Contracts;
    using Easter.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Egg : IEgg
    {
        private string name;

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

        public int EnergyRequired { get; private set; }

        public void GetColored()
        {
            this.EnergyRequired -= 10;

            if(this.EnergyRequired < 0)
            {
                this.EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
            return this.EnergyRequired == 0;
        }
    }
}

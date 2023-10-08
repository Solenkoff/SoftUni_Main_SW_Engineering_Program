namespace Easter.Models.Bunnies
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
    using Easter.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Bunny : IBunny
    {
        private string name;
        private readonly ICollection<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }


        public int Energy { get; protected set; }

        public ICollection<IDye> Dyes => this.dyes;

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }

        public virtual void Work()
        {
            this.Energy -= 10;

            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}

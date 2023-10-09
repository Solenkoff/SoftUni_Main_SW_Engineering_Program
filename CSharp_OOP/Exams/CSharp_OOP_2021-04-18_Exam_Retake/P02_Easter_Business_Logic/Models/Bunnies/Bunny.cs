namespace Easter.Models.Bunnies
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
    using Easter.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Bunny : IBunny
    {
        private const int Default_Energy_Decrease = 10;

        private string name;
        private int energy;
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


        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.energy = value;
            }
        }

        public ICollection<IDye> Dyes => this.dyes;

        public void AddDye(IDye dye)
            => this.dyes.Add(dye);


        public virtual void Work() 
            => this.Energy -= Default_Energy_Decrease;
        

        public override string ToString()
        {
            int notFinishedDyes = this.Dyes.Count(d => !d.IsFinished());

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}")
              .AppendLine($"Energy: {this.Energy}")
              .AppendLine($"Dyes: {notFinishedDyes} not finished");

            return sb.ToString().TrimEnd();
        }
    }
}

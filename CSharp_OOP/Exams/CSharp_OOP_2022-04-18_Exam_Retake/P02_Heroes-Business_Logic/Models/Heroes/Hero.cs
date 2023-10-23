namespace Heroes.Models.Heroes
{
    using Models.Contracts;
    using Utilities;
    using System;
    using System.Text;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name 
        { 
            get => this.name; 
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, ExceptionMessages.InvalidHeroName);

                this.name = value;
            }
        }
        

        public int Health
        {
            get => this.health;
            private set
            {
                Validator.ThrowIfValueIsBelowZero(value, ExceptionMessages.InvalidHeroHealth);

                this.health = value;
            }
        }


        public int Armour
        {
            get => this.armour;
            private set
            {
                Validator.ThrowIfValueIsBelowZero(value, ExceptionMessages.InvalidHeroArmour);

                this.armour = value;
            }
        }
        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if(value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidWeapon);
                }
               
                this.weapon = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            int armourLeft = this.Armour - points;

            if(armourLeft < 0)
            {
                this.Armour = 0;

                int damagehLeft = -armourLeft;

                int healthLeft = this.Health - damagehLeft;

                if (healthLeft < 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health = healthLeft;
                }
            }
            else
            {
                this.Armour = armourLeft;
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armour: {this.Armour}");
            sb.AppendLine($"--Weapon: {(this.Weapon == null ? "Unarmed" : this.Weapon.Name)}");

            return sb.ToString().Trim();
        }

    }
}

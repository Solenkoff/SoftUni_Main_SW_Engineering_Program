namespace Heroes.Models.Weapons
{

    using Contracts;
    using Utilities;

    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durabiliy;
 
        protected Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;         
        }


        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, ExceptionMessages.InvalidWeaponName);

                this.name = value;
            }
        }


        public int Durability
        {
            get => this.durabiliy;
            protected set
            {
                Validator.ThrowIfValueIsBelowZero(value, ExceptionMessages.InvalidWeaponDurability);

                this.durabiliy = value;
            }

        }


        //   DoDamage()  -  "Abstract" by description requirement, 
        //                   but logic would lead to using a regular method(commnented later), 
        //                   inherited from the child members.
        public abstract int DoDamage();

        //public int DoDamage()
        //{
        //    this.Durability --;

        //    if (this.Durability == 0)
        //    {
        //        return 0;
        //    }

        //    return this.Damage;
        //}

    }
}

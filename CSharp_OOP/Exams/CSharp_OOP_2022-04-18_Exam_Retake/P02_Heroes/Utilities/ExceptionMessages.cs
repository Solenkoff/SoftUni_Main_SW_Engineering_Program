namespace Heroes.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ExceptionMessages
    {
        //  Weapon
        public const string InvalidWeapon = "Weapon cannot be null.";

        public const string InvalidWeaponName = "Weapon type cannot be null or empty.";

        public const string InvalidWeaponDurability = "Durability cannot be below 0.";

        public const string InvalidWeaponType = "Invalid weapon type.";

        public const string WeaponAlreadyExists = "The weapon {0} already exists.";

        public const string WeaponDoesNotExist = "Weapon {0} does not exist.";

        

        
        //  Hero
        public const string InvalidHeroName = "Hero name cannot be null or empty.";

        public const string InvalidHeroType = "Invalid hero type.";

        public const string InvalidHeroHealth = "Hero health cannot be below 0.";

        public const string InvalidHeroArmour = "Hero armour cannot be below 0.";   

        public const string HeroAlreadyExists = "The hero {0} already exists.";

        public const string HeroDoesNotExist = "Hero {0} does not exist.";

        public const string HeroAlreadyHasWeapon = "Hero {0} is well-armed.";

    }
}

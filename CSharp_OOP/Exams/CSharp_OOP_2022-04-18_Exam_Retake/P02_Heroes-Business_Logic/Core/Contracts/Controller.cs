namespace Heroes.Core.Contracts
{
    using Models.Map;
    using Models.Weapons;
    using Repositories.Contracts;
    using Utilities;
    using Models.Contracts;
    using Models.Heroes;
    using Repositories;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HeroAlreadyExists, name));
            }

            IHero hero = type switch
            {
                nameof(Knight) => new Knight(name, health, armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidHeroType)
            };

            this.heroes.Add(hero);

            var heroAlias = type == nameof(Knight)
               ? $"Sir {hero.Name}"
               : $"{nameof(Barbarian)} {hero.Name}";

            return $"Successfully added {heroAlias} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyExists, name));
            }

            IWeapon weapon = type switch 
            {
                nameof(Mace) => new Mace(name, durability),
                nameof(Claymore) => new Claymore(name, durability),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidWeaponType)
            };

            this.weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero = this.heroes.FindByName(heroName);
            var weapon = this.weapons.FindByName(weaponName);

            if (hero == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HeroDoesNotExist, heroName));
            }

            if (weapon == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponDoesNotExist, weaponName));
            }
            
            if(hero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HeroAlreadyHasWeapon, heroName));
            }
           
            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);

            var weaponType = weapon.GetType().Name;
   
            return $"Hero {heroName} can participate in battle using a {weaponType.ToLower()}.";

        }


        public string StartBattle()
        {          
            IMap map = new Map();

            return map.Fight(this.heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToArray());
        }


        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            var sortedHeroes = this.heroes.Models.OrderBy(h => h.GetType().Name)
                                                 .ThenByDescending(h => h.Health)
                                                 .ThenBy(h => h.Name);
            foreach (var hero in sortedHeroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}

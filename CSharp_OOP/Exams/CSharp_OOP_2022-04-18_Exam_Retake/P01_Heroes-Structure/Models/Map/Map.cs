namespace Heroes.Models.Map
{
    using Contracts;
    using Heroes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Map : IMap
    {   

        public string Fight(ICollection<IHero> players)
        {
            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();

            foreach (var player in players)
            {
                if(player is Knight knight)
                {
                    knights.Add(knight);
                }
                else if(player is Barbarian barbarian)
                {
                    barbarians.Add(barbarian);
                }
                else
                {
                    throw new InvalidOperationException("Invalid player type!");
                }
            }

           

            while (true)
            {
                foreach (var knight in knights.Where(kn => kn.IsAlive))
                {
                    foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }

                    if(barbarians.All(b => b.IsAlive == false))
                    {
                        return $"The knights took {knights.Where(kn => kn.IsAlive == false).Count()} casualties but won the battle.";

                    }
                }

                foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                {
                    foreach (var knight in knights.Where(kn => kn.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }

                    if (knights.All(kn => kn.IsAlive == false))
                    {
                        return $"The barbarians took {barbarians.Where(b => b.IsAlive == false).Count()} casualties but won the battle.";
                    }
                }
            }

            
        }
    }
}

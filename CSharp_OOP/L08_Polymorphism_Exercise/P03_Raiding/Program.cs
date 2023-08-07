using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heros = new List<BaseHero>();

            int herosSetCoount = int.Parse(Console.ReadLine());

            while (heros.Count < herosSetCoount)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                

                BaseHero newHero = CreateHero(heroType, heroName);

                if(newHero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heros.Add(newHero);

            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heros)
            {
                Console.WriteLine(hero.Castability());
            }

            int herosPowerSum = heros.Sum(x => x.Power);

            if (herosPowerSum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }

        private static BaseHero CreateHero(string heroType, string heroName)
        {
            BaseHero newHero = null; 

            if (heroType == nameof(Druid))
            {
                newHero = new Druid(heroName);
            }
            else if (heroType == nameof(Paladin))
            {
                newHero = new Paladin(heroName);
            }
            else if (heroType == nameof(Rogue))
            {
                newHero = new Rogue(heroName);
            }
            else if (heroType == nameof(Warrior))
            {
                newHero = new Warrior(heroName);
            }
            //else
            //{
            //    Console.WriteLine("Invalid hero!");
            //    continue;
            //}
            return newHero;
        }
    }
}

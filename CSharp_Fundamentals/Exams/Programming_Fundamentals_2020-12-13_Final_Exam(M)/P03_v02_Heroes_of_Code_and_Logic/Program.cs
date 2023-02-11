using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_v02_Heroes_of_Code_and_Logic
{
    class Program
    {
        static void Main(string[] args)
        {

            int nNames = int.Parse(Console.ReadLine());

            List<Hero> heros = new List<Hero>();

            for (int i = 0; i < nNames; i++)
            {
                string[] herosData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = herosData[0];
                int hitPoints = int.Parse(herosData[1]);
                int manaPoints = int.Parse(herosData[1]);

                Hero newHero = new Hero(heroName, hitPoints, manaPoints);
                heros.Add(newHero);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string heroName = commands[1];
                int index = heros.FindIndex(x => x.Name == heroName);

                if (command == "CastSpell")
                {
                    int neededMP = int.Parse(commands[2]);
                    string spellName = commands[3];

                    if (heros[index].MP >= neededMP)
                    {
                        heros[index].MP -= neededMP;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heros[index].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }

                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(commands[2]);
                    string attacker = commands[3];
                    heros[index].HP -= damage;

                    if (heros[index].HP > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heros[index].HP} HP left!");
                    }
                    else
                    {
                        heros.RemoveAt(index);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (command == "Recharge")
                {
                    int amount = int.Parse(commands[2]);
                    heros[index].MP += amount;

                    if (heros[index].MP > 200)
                    {
                        int realCharge = amount - (heros[index].MP - 200);
                        heros[index].MP = 200;
                        Console.WriteLine($"{heroName} recharged for {realCharge} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }

                }
                else if (command == "Heal")
                {
                    int amount = int.Parse(commands[2]);
                    heros[index].HP += amount;

                    if (heros[index].HP > 100)
                    {
                        int realCharge = amount - (heros[index].HP - 100);
                        heros[index].HP = 100;
                        Console.WriteLine($"{heroName} healed for {realCharge} HP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }

                }

                input = Console.ReadLine();
            }

            foreach (var item in heros.OrderByDescending(x => x.HP).ThenBy(x => x.Name).Where(x => x.HP > 0))
            {
                Console.WriteLine(item.Name);
                Console.WriteLine($"  HP: {item.HP}");
                Console.WriteLine($"  MP: {item.MP}");
            }

        }
    }

    class Hero
    {
        public Hero(string name, int hitPoints, int manaPoints)
        {
            Name = name;
            HP = hitPoints;
            MP = manaPoints;

        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

    }

}

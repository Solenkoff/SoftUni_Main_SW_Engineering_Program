using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Hero hero = new Hero("Gogi", 19);

            Console.WriteLine(hero);

            BladeKnight knight = new BladeKnight("Bobo", 83);

            Console.WriteLine(knight);

        }
    }
}

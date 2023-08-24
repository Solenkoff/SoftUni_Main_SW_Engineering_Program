using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        Warrior warrior;
        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Name", 10, 100);
        }

        [Test]
        public void Ctor_SetsInicialValues_WhenArgumentsAreValid()
        {
            string name = "Name";
            int damage = 20;
            int hp = 200;

            Warrior newWarrior = new Warrior(name, damage, hp);

            Assert.That(newWarrior.Name, Is.EqualTo(name));
            Assert.That(newWarrior.Damage, Is.EqualTo(damage));
            Assert.That(newWarrior.HP, Is.EqualTo(hp));
        }

        [Test]
        [TestCase("", 50, 100)]
        [TestCase("  ", 50, 100)]
        [TestCase(null, 50, 100)]
        [TestCase("Name", 0, 100)]
        [TestCase("Name", -10, 100)]
        [TestCase("Name", 50, -50)]
        
        public void Ctor_ThrowsException_WhenDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }


        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]
        public void Attack_ThrowsException_WhenHpIsLessThenMinimun(int attackerHp, int warriorHp)
        {
            var attacker = new Warrior("Attacker", 50, attackerHp);
            var warrior = new Warrior("Warrior", 10, warriorHp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }


        [Test]
        public void Attack_ThrowsException_WhenAttakcersHpIsLowerThenWarriorsDamage()
        {
            var attacker = new Warrior("Attacker", 50, 40);
            var warrior = new Warrior("Warrior", 100, 200);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }


        [Test]
        public void Attack_LowersAttackersHp_WhenArgumentsAreValid()
        {
            int attackersHp = 200;
            int warriorsDamage = 50;
            var attacker = new Warrior("Attacker", 100, attackersHp);
            var warrior = new Warrior("Warrior", warriorsDamage, 200);

            attacker.Attack(warrior);

            Assert.That(attacker.HP, Is.EqualTo(attackersHp - warriorsDamage));
        }


        [Test]
        public void Attack_SetsWarriorsHpToZero_WhenWarriorsHpIsLowerThenAttackersDamage()
        {
            var attacker = new Warrior("Attacker", 100, 200);
            var warrior = new Warrior("Warrior", 50, 50);

            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(0));
        }


        [Test]
        public void Attack_LowersWorriorsHp_WhenArgumentsAreValid()
        {
            int warriorHp = 200;
            int attackersDamage = 50;
            var attacker = new Warrior("Attacker", attackersDamage, 200);
            var warrior = new Warrior("Warrior", 100, warriorHp);

            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(warriorHp - attackersDamage));
        }


    }
}
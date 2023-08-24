using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }


        [Test]
        public void Ctor_InitializesWorriors()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }


        [Test]
        public void Count_IsZero_WhenArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }


        [Test]
        public void Enroll_ThrowsException_WhenWarriorAlreadyExists()
        {
            Warrior warrior = new Warrior("Warrior", 50, 200);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior(warrior.Name, 50, 100)));
        }


        [Test]
        public void Enroll_IncreasesArenaCount()
        {
            Warrior warrior = new Warrior("Warrior", 50, 200);
            this.arena.Enroll(warrior);

            Assert.That(this.arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_AddsWorriorToWarriors()
        {
            string name = "Warrior";
            this.arena.Enroll(new Warrior(name, 50, 200));

            Assert.That(this.arena.Warriors.Any(x => x.Name == name), Is.True);
        }


        [Test]
        public void Fight_ThrowsException_WhenDefenderDoesNotExist()
        {
            string attacker = "Attacker";
            
            this.arena.Enroll(new Warrior(attacker, 50,200));

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker, "Defender"));
        }


        [Test]
        public void Fight_ThrowsException_WhenAttackerDoesNotExist()
        {
            string defender = "Defender";

            this.arena.Enroll(new Warrior(defender, 50, 200));

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Attacker", defender));
        }


        [Test]
        public void Fight_ThrowsException_WhenAttackerAndDefenderDoNotExist()
        {

            this.arena.Enroll(new Warrior("Name", 50, 200));

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Attacker", "Defender"));
        }


        [Test]
        public void Fight_BothSidesLooseHp()
        {
            int initialHp = 200;

            Warrior attacker = new Warrior("Attacker", 50, initialHp);
            Warrior defender = new Warrior("Defender", 50, initialHp);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(initialHp - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(initialHp - attacker.Damage));
        }
    }
}

using NUnit.Framework;
using System;


namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
        }


        [Test]
        public void SetsDriverCountToZero()
        {
            Assert.That(this.raceEntry.Counter, Is.EqualTo(0));
        }


        [Test]
        public void When_AddingDriver_CountIncreases()
        {
            
            this.raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("VW", 100, 3.5)));

            Assert.That(this.raceEntry.Counter, Is.EqualTo(1));
        }


        [Test]
        public void AddDiver_ThrowException_WhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(null));
        }


        [Test]
        public void AddDiver_ThrowException_WhenDriverExists()
        {
            string name = "Pesho";
            this.raceEntry.AddDriver(new UnitDriver(name, new UnitCar("VW", 100, 3.5)));
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(new UnitDriver(name, new UnitCar("BMW", 200, 4.5))));
        }


        [Test]
        public void AddDiver_ReturnsCOrrectMessage()
        {
            string name = "Pesho";
           string result = this.raceEntry.AddDriver(new UnitDriver(name, new UnitCar("VW", 100, 3.5)));

            Assert.That(result, Is.EqualTo($"Driver {name} added in race."));
        }

        [Test]
        public void When_DriversAreLessThenMin_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
            this.raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("VW", 100, 3.5)));
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }



        [Test]
        public void CalculatesAverageHorsePower_WhenDataIsCorrect()
        {
            int n = 10;
            double expected = 0;

            for (int i = 0; i < n; i++)
            {
                int hp = 450 + i;
                expected += hp;

                this.raceEntry.AddDriver(new UnitDriver($"Name-{i}", new UnitCar("VW", hp, 3.5)));
            }

            expected /= n;

            double actual = this.raceEntry.CalculateAverageHorsePower();
            Assert.That(actual, Is.EqualTo(expected));
        }
        
    }
}
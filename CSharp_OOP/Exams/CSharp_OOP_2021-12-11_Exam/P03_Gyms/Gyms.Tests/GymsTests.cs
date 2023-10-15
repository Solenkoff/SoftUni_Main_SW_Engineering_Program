using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        // Implement unit tests here
        private Athlete one;
        private Athlete two;
        private Athlete three;
        private Gym emptyGym;
        private Gym fullGym;


        [SetUp]
        public void SetUP()
        {
            one = new Athlete("One");
            two = new Athlete("Two");
            three = new Athlete("Three");
            emptyGym = new Gym("Empty", 2);
            fullGym = new Gym("Full", 3);
            fullGym.AddAthlete(one);
            fullGym.AddAthlete(two);
            fullGym.AddAthlete(three);
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_NameIsNullOrEmpty_ConstructorShouldThrowArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Gym(name, 3);
            }, "Invalid gym name.");
        }


        [Test]
        [TestCase(-1)]
        [TestCase(-111)]
        public void When_CapacityIsNegative_ConstructorShouldThrowArgumentException(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Gym("New", capacity);
            }, "Invalid gym capacity.");
        }


        [Test]
        public void CountGetter_GetsTheCountOfAthlets()
        {
            Assert.AreEqual(0, this.emptyGym.Count);

            this.emptyGym.AddAthlete(one);
            this.emptyGym.AddAthlete(two);

            Assert.AreEqual(2, this.emptyGym.Count);
        }

        [Test]
        public void When_GymIsFull_AddAthleteShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.fullGym.AddAthlete(new Athlete("New"));
            }, "The gym is full.");
        }


        [Test]
        public void AddAthlete_WorksCorrectly()
        {
            this.emptyGym.AddAthlete(one);
            Assert.AreEqual(1, this.emptyGym.Count);

            this.emptyGym.AddAthlete(two);
            Assert.AreEqual(2, this.emptyGym.Count);
        }


        [Test]
        [TestCase("Boko")]
        [TestCase("")]
        public void When_AthletDoesNotExist_RemoveAthleteShouldThrowInvalidOperationException(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.fullGym.RemoveAthlete(name);
            }, $"The athlete {name} doesn't exist.");
        }


        [Test]
        public void RemoveAthlete_WorksCorrectly()
        {
            this.fullGym.RemoveAthlete("Three");

            Assert.AreEqual(2, this.fullGym.Count);
        }


        [Test]
        [TestCase("Boko")]
        [TestCase("")]
        public void When_AthletDoesNOtExist_InjureAthleteShouldThrowInvalidOperationException(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.fullGym.InjureAthlete(name);
            }, $"The athlete {name} doesn't exist.");
        }


        [Test]
        public void InjureAthlete_SetsAthletInjured()
        {
            this.emptyGym.AddAthlete(one);
            emptyGym.InjureAthlete(one.FullName);

            Assert.IsTrue(one.IsInjured);
        }

        [Test]
        public void InjureAthlete_ReturnesTheCorrectAthlet()
        {
            Athlete newAthlete = new Athlete("Boko");
            
            this.emptyGym.AddAthlete(newAthlete);

            Athlete injuredAthlete = this.emptyGym.InjureAthlete(newAthlete.FullName);

            Assert.IsTrue(injuredAthlete.IsInjured);
        }

        [Test]
        public void Report_ReturnsTheCorrectString()
        {
            string expected = $"Active athletes at {this.fullGym.Name}: One, Two, Three";
            string actual = this.fullGym.Report();

            string expectedTwo = $"Active athletes at {this.emptyGym.Name}: ";
            string actualTwo = this.emptyGym.Report();

            this.fullGym.InjureAthlete(one.FullName);
            string expectedThree = $"Active athletes at {this.fullGym.Name}: Two, Three";
            string actualThree = this.fullGym.Report();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedTwo, actualTwo);
            Assert.AreEqual(expectedThree, actualThree);
        }

 
    }
}

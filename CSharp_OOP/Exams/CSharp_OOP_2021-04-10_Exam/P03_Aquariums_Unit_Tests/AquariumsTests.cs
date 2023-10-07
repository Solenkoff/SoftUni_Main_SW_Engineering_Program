namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {

        private Fish one;
        private Fish two;
        private Fish three;
        private Aquarium smallAquarium;
        private Aquarium bigAquarium;

        [SetUp]
        public void SetUp()
        {
            one = new Fish("One");
            two = new Fish("Two");
            three = new Fish("Three");
            smallAquarium = new Aquarium("Small", 2);
            bigAquarium = new Aquarium("Big", 10);
        }



        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_AquariumNameIsNullOrEmpty_ShouldThrowArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Aquarium(name, 7);
            }, "Invalid aquarium name!");
        }


        [Test]
        [TestCase(-1)]
        [TestCase(-111)]
        public void When_CapacityIsNegative_ShouldThrowArgumentException(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Aquarium("Brr", capacity);
            }, "Invalid aquarium capacity!");
        }


        [Test]
        public void CountGetter_ShouldReturnTheCountOffFish()
        {
            Assert.AreEqual(0, this.bigAquarium.Count);
            bigAquarium.Add(one);
            bigAquarium.Add(two);
            Assert.AreEqual(2, this.bigAquarium.Count);
        }

        [Test]
        public void When_AquariumFull_AddShouldThrowInvalidOperationException()
        {
            smallAquarium.Add(one);
            smallAquarium.Add(two);
            Assert.Throws<InvalidOperationException>(() =>
            {
                smallAquarium.Add(three);
            }, "Aquarium is full!");
        }

        [Test]
        public void AddWorksCorrectly()
        {
            bigAquarium.Add(one);
            bigAquarium.Add(two);
            bigAquarium.Add(three);
            Assert.AreEqual(3, this.bigAquarium.Count);
        }

        [Test]
        public void When_FishDoesNotExist_RemoveFishShouldThrowInvalidOperationException()
        {
            smallAquarium.Add(one);
            Assert.Throws<InvalidOperationException>(() =>
            {
                smallAquarium.RemoveFish("Missing");
            }, $"Fish with the name {one.Name} doesn't exist!");
        }


        [Test]
        public void RemoveFishWorksCorrectly()
        {
            bigAquarium.Add(one);
            bigAquarium.Add(two);
            bigAquarium.Add(three);
            bigAquarium.RemoveFish(three.Name);
            Assert.AreEqual(2, this.bigAquarium.Count);
        }


        [Test]
        public void When_FishDoesNotExist_SellFishShouldThrowInvalidOperationException()
        {
            smallAquarium.Add(one);
            Assert.Throws<InvalidOperationException>(() =>
            {
                smallAquarium.SellFish("Missing");
            }, $"Fish with the name {one.Name} doesn't exist!");
        }

        [Test]
        public void SellFishWorksCorrectly()
        {
            bigAquarium.Add(one);
            bigAquarium.Add(two);
            bigAquarium.Add(three);
            bigAquarium.SellFish(three.Name);
            Assert.IsFalse(three.Available);
        }


        [Test]
        public void SellFish_ReturnsTheCorrectFish()
        {
            string name = "Ivo";
            Fish newFish = new Fish(name);
            bigAquarium.Add(one);
            bigAquarium.Add(two);
            bigAquarium.Add(newFish);

            Fish soldFish = bigAquarium.SellFish(name);

            Assert.AreEqual(name, soldFish.Name);
        }


        [Test]
        public void ReportWorksCorrectly()
        {
            smallAquarium.Add(one);
            smallAquarium.Add(two);
            string expected = $"Fish available at {smallAquarium.Name}: {one.Name}, {two.Name}";
            string actual = smallAquarium.Report();
            Assert.AreEqual(expected, actual);
        }

    }
}

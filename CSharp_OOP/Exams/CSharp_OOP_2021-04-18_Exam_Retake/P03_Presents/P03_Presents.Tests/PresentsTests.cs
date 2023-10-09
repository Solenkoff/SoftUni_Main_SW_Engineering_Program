namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Present presentOne;
        private Present presentTwo;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            presentOne = new Present("One", 5.5);
            presentTwo = new Present("Two", 4.4);
            bag = new Bag();
        }

        [Test]
        public void PresentSetsCorrectly()
        {
            Present newPresent = new Present("Some", 4.4);
            Assert.AreEqual("Some", newPresent.Name);
            Assert.AreEqual(4.4, newPresent.Magic);
        }

        [Test]
        public void BagSetsCorrectly()
        {
            Bag newBag = new Bag();
            Assert.IsNotNull(newBag);
        }


        [Test]
        public void When_PresentIsNull_CreateThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void When_PresentExists_CreateThrowsInvalidOperationException()
        {
            bag.Create(presentOne);
            Assert.Throws<InvalidOperationException>(() => bag.Create(presentOne));
        }

        [Test]
        public void Create_ReturnsCorrectly()
        {
            string expected = "Successfully added present One.";
            Assert.AreEqual(expected, bag.Create(presentOne));
        }

        [Test]
        public void Remove_ReturnsCorrectly()
        {
            bag.Create(presentOne);
            Assert.AreEqual(true, bag.Remove(presentOne));
            Assert.AreEqual(false, bag.Remove(presentOne));
        }

        [Test]
        public void GetPresentWithLeastMagic_ReturnsCorrectly()
        {
            bag.Create(presentOne);
            bag.Create(presentTwo);
            Assert.AreEqual(presentTwo, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void GetPresent_ReturnsCorrectly()
        {
            bag.Create(presentOne);
            bag.Create(presentTwo);
            Assert.AreEqual(presentTwo, bag.GetPresent("Two"));
        }

        [Test]
        public void GetPresents_ReturnsCorrectly()
        {
            bag.Create(presentOne);
            bag.Create(presentTwo);
            List<Present> copyBag = new List<Present>{ presentOne, presentTwo };
            CollectionAssert.AreEqual(copyBag, bag.GetPresents());
        }




    }
}

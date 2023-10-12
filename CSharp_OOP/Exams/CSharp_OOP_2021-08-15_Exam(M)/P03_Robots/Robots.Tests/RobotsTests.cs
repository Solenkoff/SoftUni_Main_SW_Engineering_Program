namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {

        private Robot one;
        private Robot two;
        private Robot three;
        private RobotManager emptyMenager;
        private RobotManager fullMenager;


        [SetUp]
        public void SetUp()
        {
            one = new Robot("One", 20);
            two = new Robot("Two", 30);
            three = new Robot("Three", 40);
            emptyMenager = new RobotManager(10);
            fullMenager = new RobotManager(2);
            fullMenager.Add(one);
            fullMenager.Add(two);
        }


        [Test]
        public void RobotSetsCorrecty()
        {
            string name = "Ivo";
            int maxBattery = 10;

            Robot newRobot = new Robot(name, maxBattery);

            Assert.IsNotNull(newRobot);
            Assert.AreEqual(name, newRobot.Name);
            Assert.AreEqual(maxBattery, newRobot.MaximumBattery);
            Assert.AreEqual(maxBattery, newRobot.Battery);
        }



        [Test]
        [TestCase(-1)]
        [TestCase(-111)]
        public void When_NegativeValueIsGivenForCapacity_CTORShouldThrowArgumentException(int capacity)
        {
             Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1111)]
        public void CTOR_SetsCorrectly(int capacity)
        {
            RobotManager newRM = new RobotManager(capacity);
            Assert.AreEqual(capacity, newRM.Capacity);
        }

        [Test]
        public void CountGetter_ReturnesCorrectly()
        {
            Assert.AreEqual(0, this.emptyMenager.Count);
            this.emptyMenager.Add(one);
            this.emptyMenager.Add(two);
            Assert.AreEqual(2, this.emptyMenager.Count);
        }

        [Test]
        public void When_RobotWithSameNameAlreadyExists_AddShouldThrowIOE()
        {
            this.emptyMenager.Add(one);
            this.emptyMenager.Add(two);
            Assert.Throws<InvalidOperationException>(() => this.emptyMenager.Add(one));
        }

        [Test]
        public void When_RobotsCountReachedCapacity_AddShouldThrowIOE()
        {
            Assert.Throws<InvalidOperationException>(() => this.fullMenager.Add(three));
        }


        [Test]
        public void Add_WorksCorrectly()
        {
            this.emptyMenager.Add(one);
            this.emptyMenager.Add(two);
            this.emptyMenager.Add(three);
            Assert.AreEqual(3, this.emptyMenager.Count);
        }


        [Test]
        public void When_RobotDoesNotExist_RemoveShouldThrowIOE()
        {
            Assert.Throws<InvalidOperationException>(() => this.emptyMenager.Remove(one.Name));
            Assert.Throws<InvalidOperationException>(() => this.fullMenager.Remove(three.Name));
        }

        [Test]
        public void Remove_WorksCorrectly()
        {           
            Assert.AreEqual(2, this.fullMenager.Count);
            this.fullMenager.Remove(one.Name);
            Assert.AreEqual(1, this.fullMenager.Count);
            this.fullMenager.Remove(two.Name);
            Assert.AreEqual(0, this.fullMenager.Count);
        }

        [Test]
        public void When_RobotDoesNotExist_WorkShouldThrowIOE()
        {
            Assert.Throws<InvalidOperationException>(() => this.emptyMenager.Work(one.Name, "Neshto", 14));
            Assert.Throws<InvalidOperationException>(() => this.fullMenager.Work(three.Name, "Nishto", 7));
        }

        [Test]
        public void When_RobotsBatteryIsNotEnough_WorkShouldThrowIOE()
        {
            Assert.Throws<InvalidOperationException>(() => this.fullMenager.Work(one.Name, "Nishto", 33));
        }

        [Test]
        public void Work_WorksCorrectly()
        {
            this.fullMenager.Work(one.Name, "Nishto", 7);
            Assert.AreEqual(13, one.Battery);
        }

        [Test]
        public void When_RobotDoesNotExist_ChargeShouldThrowIOE()
        {
            Assert.Throws<InvalidOperationException>(() => this.emptyMenager.Charge(one.Name));
            Assert.Throws<InvalidOperationException>(() => this.fullMenager.Charge(three.Name));
        }

        [Test]
        public void Charge_WorksCorrectly()
        {
            this.fullMenager.Work(one.Name, "Nishto", 7);
            this.fullMenager.Charge(one.Name);
            Assert.AreEqual(20, one.Battery);
        }


    }
}

using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {

        Smartphone one;
        Smartphone two;
        Smartphone three;
        Shop emptyShop;
        Shop fullShop;

        [SetUp]
        public void SetUp()
        {
            this.one = new Smartphone("One/", 100);
            this.two = new Smartphone("Two", 50);
            this.three = new Smartphone("Three/", 10);
            emptyShop = new Shop(2);
            fullShop = new Shop(3);
            fullShop.Add(one);
            fullShop.Add(two);
            fullShop.Add(three);
        }


        [Test]
        [TestCase(-1)]
        [TestCase(-111)]
        public void When_CapacityIsnegative_ShouldThrowArgumentException(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Shop(capacity);
            }, "Invalid capacity.");
        }


        [Test]
        public void CountGetter_ShouldWorkProperly()
        {
            Assert.AreEqual(0, this.emptyShop.Count);
            this.emptyShop.Add(one);
            Assert.AreEqual(1, this.emptyShop.Count);
        }


        [Test]
        public void When_PhoneExists_AddSouldThrowInvalidOperationException()
        {
            this.emptyShop.Add(one);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.emptyShop.Add(one);
            }, $"The phone model {one.ModelName} already exist.");
        }

        [Test]
        public void When_ShopIsFull_AddSouldThrowInvalidOperationException()
        {
            Smartphone newPhone = new Smartphone("New", 50);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.fullShop.Add(newPhone);
            }, "The shop is full.");
        }

        [Test]
        public void When_PhoneDoesNotExist_RemoveSouldThrowInvalidOperationException()
        {
            string nonExistentname = "Brrr";
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.fullShop.Remove("NonExistent");
            }, $"The phone model {nonExistentname} doesn't exist.)");
        }

        [Test]
        public void Remove_ShouldWorkProperly()
        {
            Assert.AreEqual(3, this.fullShop.Count);
            this.fullShop.Remove(three.ModelName);
            Assert.AreEqual(2, this.fullShop.Count);
        }


        [Test]
        public void When_PhoneDoesNotExist_TestPhoneSouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.emptyShop.TestPhone(one.ModelName, 20);
            }, $"The phone model {one.ModelName} doesn't exist.");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.fullShop.TestPhone("NonExistent", 30);
            }, $"The phone model NonExisten doesn't exist.");
        }

        [Test]
        [TestCase(51)]
        [TestCase(111)]
        public void When_PhonesChargeIsLessThanBatteryUsage_TestPhoneSouldThrowInvalidOperationException(int batteryUsage)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.fullShop.TestPhone(two.ModelName, batteryUsage);
            }, $"The phone model {two.ModelName} is low on batery.");
        }

        [Test]
        [TestCase(0)]
        [TestCase(20)]
        [TestCase(100)]
        public void TestPhone_ShouldWorkProperly(int batteryUsage)
        {
            int expected = one.CurrentBateryCharge - batteryUsage;
            this.fullShop.TestPhone(one.ModelName, batteryUsage);
            int actual = one.CurrentBateryCharge;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void When_PhoneDoesNotExist_ChargePhoneSouldThrowInvalidOperationException()
        {
            int oneFullCharge = one.MaximumBatteryCharge;
            int batteryUsage = 20;
            this.fullShop.TestPhone(one.ModelName, batteryUsage);
            Assert.AreEqual(oneFullCharge - batteryUsage, one.CurrentBateryCharge);

            this.fullShop.ChargePhone(one.ModelName);
            Assert.AreEqual(oneFullCharge, one.CurrentBateryCharge);
        }
    }
}
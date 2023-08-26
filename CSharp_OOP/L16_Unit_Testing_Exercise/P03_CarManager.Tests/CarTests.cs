
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            this.car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -100)]
        public void Ctort_ThtowsException_WhenDdataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_SetsInitialValues_WhenArgumentsAreValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10.0;
            double fuelCapacity = 100.0;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void Refuel_ThrowsException_WhenFuelIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }


        [Test]
        public void Refuel_AddsFuel_WhenFuelIsValid()
        {
            double fuel = this.car.FuelCapacity / 2;
            this.car.Refuel(fuel);

            Assert.That(this.car.FuelAmount, Is.EqualTo(fuel));
        }


        [Test]
        public void Refuel_AddsCorrectFuel_WhenFuelExceedsTheCapacity()
        {

            double fuel = this.car.FuelCapacity * 1.2;
            car.Refuel(fuel);

            Assert.That(this.car.FuelAmount, Is.EqualTo(this.car.FuelCapacity));

        }


        [Test]
        public void Drive_DrivesGivenDistance_WhenFuelIsValid()
        {
            this.car.Refuel(100);

            double distance = 60;
            double fuelNeeded = (distance / 100) * this.car.FuelConsumption;
            double fuelLeft = this.car.FuelAmount - fuelNeeded;

            car.Drive(distance);          

            Assert.That(this.car.FuelAmount, Is.EqualTo(fuelLeft));
        }


        [Test]
        public void Drive_ThrowsException_WhenFuelIsNotEnough()
        {
            this.car.Refuel(10);

            double distance = 200;
            double fuelNeeded = (distance / 100) * this.car.FuelConsumption;
           

            Assert.Throws<InvalidOperationException>(() => this.car.Drive(distance));
        }

    }
}
using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            Car carOne;
            Car carTwo;
            Car carThree;
            Garage idleGarage;
            Garage busyGarage;
           
            [SetUp]
            public void SetUp()
            {
                carOne = new Car("One", 2);
                carTwo = new Car("Two", 0);
                carThree = new Car("Three", 7);
                carThree = new Car("Three", 7);
                idleGarage = new Garage("MyIdleGarage", 2);
                busyGarage = new Garage("MyBusyGarage", 3);
                busyGarage.AddCar(carOne);
                busyGarage.AddCar(carTwo);
                busyGarage.AddCar(carThree);
            }

            [Test]
            public void CarIsSetProperly()
            {
                Assert.AreEqual("One", carOne.CarModel);
                Assert.AreEqual(2, carOne.NumberOfIssues);
                Assert.AreEqual(0, carTwo.NumberOfIssues);
                Assert.IsFalse(carOne.IsFixed);
                Assert.IsTrue(carTwo.IsFixed);               
            }


            [Test]
            public void ConstructorSetsGarageCorrectly()
            {
                Assert.AreEqual("MyIdleGarage", idleGarage.Name);
                Assert.AreEqual(2, idleGarage.MechanicsAvailable);
                Assert.AreEqual(0, idleGarage.CarsInGarage);


                Assert.AreEqual("MyBusyGarage", busyGarage.Name);
                Assert.AreEqual(3, busyGarage.MechanicsAvailable);
                Assert.AreEqual(3, busyGarage.CarsInGarage);
            }


            [Test]
            [TestCase("")]
            [TestCase(null)]
            public void When_NameIsNullOrEmpty_ConstructorShouldThrowArgumentNullException(string garageName)
            {
                
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage newGarage = new Garage(garageName, 4);
                }, "Invalid garage name.");
            }


            [Test]
            [TestCase(0)]
            [TestCase(-1)]
            [TestCase(-111)]
            public void When_MechanicsAvailableIsZeroOrLess_ConstructorShouldThrowArgumentException(int mechanics)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage newGarage = new Garage("Ivo's", mechanics);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void CarsInGarage_ShouldReturnTheCountOfCarsInTheGarage()
            {
                Assert.AreEqual(0, idleGarage.CarsInGarage);

                Assert.AreEqual(3, busyGarage.CarsInGarage);
            }


            [Test]
            public void WhenNoIdleMechanic_AddCarShouldThrowInvalidOperationException()
            {

                Assert.Throws<InvalidOperationException>(() =>
                {
                    busyGarage.AddCar(new Car("Tesla", 3));
                }, "No mechanic available.");
            }

            [Test]
            public void AddCarworksCorrectly()
            {
                Assert.AreEqual(0, idleGarage.CarsInGarage);
                idleGarage.AddCar(carOne);
                Assert.AreEqual(1, idleGarage.CarsInGarage); 
            }

            [Test]
            public void When_NonExistiingCar_FixCar_ShouldThrowInvalidOperationException()
            {
                string carModel = "Brrr";
                Assert.Throws<InvalidOperationException>(() =>
                {
                    busyGarage.FixCar(carModel);
                }, $"The car {carModel} doesn't exist.");
            }

            [Test]
            public void When_FixingCar_NumberOfIssuesShouldBeSetToZero()
            {
                idleGarage.AddCar(carOne);
                idleGarage.FixCar("One");
                Assert.AreEqual(0, carOne.NumberOfIssues);
            }

            [Test]
            public void FixingCar_ReturnsTheCorrectCar()
            {
                string carModel = "Brrr";
                Car nonFixedCar = new Car(carModel, 2);
                idleGarage.AddCar(nonFixedCar);

                Car fixedCar = idleGarage.FixCar(carModel);

                Assert.AreEqual(carModel, fixedCar.CarModel);
                Assert.AreEqual(0, fixedCar.NumberOfIssues);
                Assert.True(fixedCar.IsFixed == true);
            }

            [Test]
            public void When_NoCarIsFixed_RemoveFixedCar_ShouldThrowInvalidOperationException()
            {
                idleGarage.AddCar(carOne);
                idleGarage.AddCar(carThree);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    idleGarage.RemoveFixedCar();
                }, $"No fixed cars available.");
            }


            [Test]
            public void RemoveFixedCarCarworksCorrectly()
            {   
                idleGarage.AddCar(new Car("Brrr", 0));
                idleGarage.AddCar(new Car("Nova", 0));
                
                Assert.AreEqual(2, idleGarage.RemoveFixedCar());
                Assert.AreEqual(1, busyGarage.RemoveFixedCar());
            }


            [Test]
            public void Report_ReturnsTheCorrectString()
            {
                string expected = $"There are 2 which are not fixed: {carOne.CarModel}, {carThree.CarModel}.";
                string actual = busyGarage.Report();
                Assert.AreEqual(expected, actual);
            }

        }
    }
}
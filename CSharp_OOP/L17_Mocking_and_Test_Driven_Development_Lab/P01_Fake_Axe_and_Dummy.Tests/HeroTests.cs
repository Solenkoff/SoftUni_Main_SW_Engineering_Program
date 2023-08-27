using FakeAxeAndDummy.Contracts;
using Moq;
using NUnit.Framework;

namespace FakeAxeAndDummy.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void WhenTargetDies_ShouldReceiveExperience()
        {
            Mock<ITarget> mockTarget = new Mock<ITarget>();
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();

            mockTarget.Setup(t => t.IsDead()).Returns(true);
            mockTarget.Setup(t => t.GiveExperience()).Returns(20);

            //FakeTarget target = new FakeTarget();
            //FakeWeapon weapon = new FakeWeapon();

            Hero hero = new Hero("Gogo", mockWeapon.Object);

            hero.Attack(mockTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(20));
        }
    }

}



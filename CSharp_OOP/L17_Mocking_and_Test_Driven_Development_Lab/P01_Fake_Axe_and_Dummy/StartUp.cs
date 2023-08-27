using FakeAxeAndDummy.Contracts;
using Moq;

public class StartUp
{
    static void Main(string[] args)
    {
        Mock<ITarget> target = new Mock<ITarget>();
        Mock<IWeapon> weapon = new Mock<IWeapon>();

        target.Setup(t => t.TakeAttack(30));

        weapon.Setup(w => w.Attack(It.IsAny<ITarget>())).Callback(() =>
        {
            target.Object.TakeAttack(30);
        });

        weapon.Object.Attack(target.Object);
        weapon.Object.Attack(target.Object);
        weapon.Object.Attack(target.Object);

        target.Verify(t => t.TakeAttack(30), Times.Exactly(3));



        

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Contracts
{
    public interface ITarget
    {
        void TakeAttack(int attackAmount);

        bool IsDead();

        int GiveExperience();
    }
}

namespace Gym.Models.Athletes
{
    using Utilities.Messages;
    using System;

    public class Weightlifter : Athlete
    {
        private const int InitialStamina = 50;
        private const int StaminaIncrease = 10;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, InitialStamina, numberOfMedals)
        {
        }


        public override void Exercise()
        {
            if (this.Stamina + StaminaIncrease > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
            else
            {
                this.Stamina += StaminaIncrease;
            }
        }

    }
}

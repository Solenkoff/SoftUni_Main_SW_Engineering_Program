namespace Gym.Models.Athletes
{
    using Utilities.Messages;
    using System;

    public class Boxer : Athlete
    {
        private const int InitialStamina = 60;
        private const int StaminaIncrease = 15;
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, InitialStamina, numberOfMedals)
        {
        }

        public override void Exercise()
        {
            if(this.Stamina + StaminaIncrease > 100)
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

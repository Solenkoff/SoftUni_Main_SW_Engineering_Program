namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProfessionalRacer : Racer
    {
        private const int InitialDrivingExperience = 30;
        private const string StrictRacingBehavior = "strict";
        public ProfessionalRacer(string username, ICar car) 
            : base(username, StrictRacingBehavior, InitialDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}

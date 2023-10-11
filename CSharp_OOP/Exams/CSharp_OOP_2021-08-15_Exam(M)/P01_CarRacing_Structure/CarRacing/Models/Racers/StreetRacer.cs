namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StreetRacer : Racer
    {
        private const int InitialDrivingExperience = 10;
        private const string AggressiveRacingBehavior = "aggressive";
        public StreetRacer(string username, ICar car)
            : base(username, AggressiveRacingBehavior, InitialDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}

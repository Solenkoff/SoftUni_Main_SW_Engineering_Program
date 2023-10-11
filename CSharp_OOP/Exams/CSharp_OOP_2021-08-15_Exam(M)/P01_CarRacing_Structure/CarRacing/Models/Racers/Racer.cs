namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Racer : IRacer
    {
        private string userName;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }


        public string Username
        {
            get => this.racingBehavior;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, ExceptionMessages.InvalidRacerBehavior);

                this.racingBehavior = value;
            }
        }

        public string RacingBehavior
        {
            get => this.userName;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, ExceptionMessages.InvalidRacerName);

                this.userName = value;
            }
        }

        public int DrivingExperience
        {
            get => this.drivingExperience;
            protected set
            {
                if (value < 0 || value >100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => this.car;
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                this.car = value;
            }
        }


        public virtual void Race()
        {
            this.Car.Drive();
        }

        public bool IsAvailable()
        {
            return this.Car.FuelAvailable >= this.Car.FuelConsumptionPerRace;
        }

      
    }
}

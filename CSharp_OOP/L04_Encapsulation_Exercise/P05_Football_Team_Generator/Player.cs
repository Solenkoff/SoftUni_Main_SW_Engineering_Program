using System;
using System.Collections.Generic;
using System.Text;

namespace FootbalTeamGenerator
{
    public class Player
    {
        private static int MinStat = 0;
        private static int MaxStat = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;


        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }               

        public string Name 
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, GlobalConstants.InvalidNameErrorMessage);

                this.name = value;
            }          
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(value, MinStat, MaxStat, 
                    $"{nameof(this.Endurance)} should be between {MinStat} and {MaxStat}.");

                this.endurance = value;
            }
        }


        public int Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(value, MinStat, MaxStat,
                    $"{nameof(this.Sprint)} should be between {MinStat} and {MaxStat}.");

                this.sprint = value;
            }
        }


        public int Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(value, MinStat, MaxStat,
                    $"{nameof(this.Dribble)} should be between {MinStat} and {MaxStat}.");

                this.dribble = value;
            }
        }


        public int Passing
        {
            get => this.passing;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(value, MinStat, MaxStat,
                    $"{nameof(this.Passing)} should be between {MinStat} and {MaxStat}.");

                this.passing = value;
            }
        }


        public int Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(value, MinStat, MaxStat,
                    $"{nameof(this.Shooting)} should be between {MinStat} and {MaxStat}.");

                this.shooting = value;
            }
        }

        public double AverageSkillPoints => 
            (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
    }
}

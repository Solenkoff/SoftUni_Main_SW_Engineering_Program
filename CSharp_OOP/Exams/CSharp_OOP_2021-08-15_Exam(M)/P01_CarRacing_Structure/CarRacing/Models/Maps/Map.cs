namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            IRacer winner = null;
            IRacer looser = null;
            string message = "";

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                message =  OutputMessages.RaceCannotBeCompleted; 
            }
            else if (!racerTwo.IsAvailable())
            {
                winner = racerOne;
                looser = racerTwo;
                message = string.Format(OutputMessages.OneRacerIsNotAvailable, winner.Username, looser.Username);
            }
            else if (!racerOne.IsAvailable())
            {
                winner = racerTwo;
                looser = racerOne;
                message = string.Format(OutputMessages.OneRacerIsNotAvailable, winner.Username, looser.Username);
            }
            else
            {
                double chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * 
                    (racerOne.RacingBehavior == "strict" ? 1.2 : 1.1);
                double chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience *
                   (racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1);
                if(chanceOfWinningOne > chanceOfWinningTwo)
                {
                    winner = racerOne;
                    looser = racerTwo;
                }
                else
                {
                    winner = racerTwo;
                    looser = racerOne;
                }

                looser.Race();

                message = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
            }

            winner.Race();

            return message;
        }

    }
}

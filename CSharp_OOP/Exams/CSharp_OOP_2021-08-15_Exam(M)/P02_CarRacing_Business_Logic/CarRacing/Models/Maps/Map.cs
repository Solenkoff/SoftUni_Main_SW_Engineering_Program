namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            double chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience *
                (racerOne.RacingBehavior == "strict" ? 1.2 : 1.1);
            double chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience *
               (racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1);

            IRacer winner = chanceOfWinningOne > chanceOfWinningTwo ? racerOne : racerTwo;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);

        }

    }
}

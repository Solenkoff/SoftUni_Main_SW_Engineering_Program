

namespace _06_Speed_Racing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double consumption, int travelledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelPerKm = consumption;
            this.TravelledDistance = travelledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelPerKm { get; set; }
        public double TravelledDistance { get; set; }


        public static bool DistanceCovoringPossibility(Car currCar, double amountOfKm)
        {
            bool isPossible = true;

            if (currCar.FuelAmount < currCar.FuelPerKm * amountOfKm)
            {
                isPossible = false;
            }

            return isPossible;

        }

    }
}

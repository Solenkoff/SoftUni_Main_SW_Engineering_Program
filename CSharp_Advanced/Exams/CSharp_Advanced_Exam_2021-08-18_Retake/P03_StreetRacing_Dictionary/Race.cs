using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private Dictionary<string, Car> Participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new Dictionary<string, Car>();
        }


        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => this.Participants.Count;

       
        public void Add(Car car)
        {
            bool alreadyExists = this.Participants.ContainsKey(car.LicensePlate);

            if(!alreadyExists && this.Capacity > this.Count && car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car.LicensePlate, car);
            }
        }

        public bool Remove(string licensePlate)
        {
            return this.Participants.Remove(licensePlate);
        }

        public Car FindParticipant(string licensePlate)
        {
            return this.Participants.FirstOrDefault(c => c.Key == licensePlate).Value;
        }


        public Car GetMostPowerfulCar()
        {
            return this.Participants.Values.OrderByDescending(c => c.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var car in this.Participants)
            {
                sb.AppendLine($"{car.Value.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}

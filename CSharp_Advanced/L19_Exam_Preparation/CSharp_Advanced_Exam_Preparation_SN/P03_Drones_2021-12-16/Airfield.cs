using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {

        private readonly List<Drone> Drones;
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count => this.Drones.Count;


        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (this.Drones.Count == this.Capacity)
            {
                return "Airfield is full.";
            }

            this.Drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone drone = this.Drones.FirstOrDefault(d => d.Name == name);
            if (drone != null)
            {
                this.Drones.Remove(drone);
                return true;
            }

            return false;
        }


        public int RemoveDroneByBrand(string brand)
        {
            Drone[] dronesByBrand = this.Drones.FindAll(d => d.Brand == brand).ToArray();

            if (dronesByBrand.Length > 0)
            {
                foreach (var drone in dronesByBrand)
                {
                    this.Drones.Remove(drone);
                }

                return dronesByBrand.Length;
            }

            return 0;
        }


        public Drone FlyDrone(string name)
        {
            Drone drone = this.Drones.FirstOrDefault(d => d.Name == name);
            if (drone != null)
            {
                drone.Available = false;
                return drone;
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesInRange = this.Drones.FindAll(d => d.Range >= range).ToList();

            foreach (var drone in dronesInRange)
            {
                drone.Available = false;
            }

            return dronesInRange;
        }


        public string Report()
        {
            List<Drone> dronesNotInFlight = this.Drones.FindAll(d => d.Available == true).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var drone in dronesNotInFlight)
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}

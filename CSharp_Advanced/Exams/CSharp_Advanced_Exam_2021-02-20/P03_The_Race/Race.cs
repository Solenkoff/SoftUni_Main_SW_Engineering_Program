using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_The_Race
{
    public class Race
    {
        private List<Racer> racers;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.racers = new List<Racer>();
        }


        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return racers.Count; } }


        public void Add(Racer racer)
        {
            if (this.racers.Count < this.Capacity)
            {
                this.racers.Add(racer);
            }
        }


        public bool Remove(string name)
        {
            Racer racer = racers.FirstOrDefault(x => x.Name == name);
            if (racer == null)
            {
                return false;
            }
            else
            {
                racers.Remove(racer);
                return true;
            }
        }


        public Racer GetOldestRacer()
        {
            return racers.OrderByDescending(x => x.Age).FirstOrDefault();
        }


        public Racer GetRacer(string name)
        {
            return racers.FirstOrDefault(x => x.Name == name);
        }


        public Racer GetFastestRacer()
        {
            return racers.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (Racer item in racers)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    class Parking
    {

        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;


        public void Add(Car car)
        {
            if(this.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }


        public bool Remove(string manufacturer, string model)
        {
            bool removed = false;

            Car car = this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if( this.data.Contains(car))
            {
                this.data.Remove(car);
                removed = true;
            }

            return removed;
        }


        public Car GetLatestCar()
        {
            return this.data.OrderByDescending(x => x.Year).FirstOrDefault();
        }


        public Car GetCar(string manufacturer, string model)
        {
            return this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }


        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }


    }
}

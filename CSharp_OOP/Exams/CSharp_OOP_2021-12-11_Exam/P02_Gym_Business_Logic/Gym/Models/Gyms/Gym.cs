namespace Gym.Models.Gyms
{
    using Utilities;
    using Utilities.Messages;
    using Models.Gyms.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models.Equipment.Contracts;
    using Models.Athletes.Contracts;
    using System.Linq;

    public abstract class Gym : IGym
    {
        private string name;
        private ICollection<IEquipment> equipment;
        private ICollection<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new HashSet<IEquipment>();
            this.athletes = new HashSet<IAthlete>();
        }

        public string Name         
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.InvalidGymName);

                this.name = value;
            }
        }

        public int Capacity { get; private set; }
        
        public double EquipmentWeight => (double)this.Equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;


        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == this.Athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.Athletes.Add(athlete); 
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);            
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");

            if(this.Athletes.Count == 0)
            {
                sb.AppendLine("Athletes: No athletes");
            }
            else
            {
                string[] athleteNames = this.Athletes.Select(a => a.FullName).ToArray();   
                sb.AppendLine($"Athletes: {string.Join(", ", athleteNames)}");
            }

            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }
       
    }
}

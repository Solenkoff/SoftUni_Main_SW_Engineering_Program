namespace Gym.Core
{
    using Core.Contracts;
    using Models.Athletes;
    using Models.Athletes.Contracts;
    using Models.Equipment;
    using Models.Equipment.Contracts;
    using Models.Gyms;
    using Models.Gyms.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {

        private IRepository<IEquipment> equipmentRepository;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipmentRepository = new EquipmentRepository();
            this.gyms = new HashSet<IGym>();
        }


        public string AddGym(string gymType, string gymName)
        {
            IGym gym = gymType switch 
            {
                nameof(BoxingGym) => new BoxingGym(gymName),
                nameof(WeightliftingGym) => new WeightliftingGym(gymName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidGymType)
            };

            this.gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }


        public string AddEquipment(string equipmentType)
        {
            IEquipment newEquipment = equipmentType switch
            {
                nameof(BoxingGloves) => new BoxingGloves(),
                nameof(Kettlebell) => new Kettlebell(),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType)
            };

            this.equipmentRepository.Add(newEquipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }


        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipmentRepository.FindByType(equipmentType);
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            if(equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(equipment);
            this.equipmentRepository.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }


        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            IAthlete athlete = athleteType switch
            {
                nameof(Boxer) => new Boxer(athleteName, motivation ,numberOfMedals),
                nameof(Weightlifter) => new Weightlifter(athleteName, motivation, numberOfMedals),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType)
            };

            if((athlete.GetType().Name == nameof(Boxer) && gym.GetType().Name == nameof(WeightliftingGym)) ||
               (athlete.GetType().Name == nameof(Weightlifter) && gym.GetType().Name == nameof(BoxingGym)) )
            {
                return OutputMessages.InappropriateGym;
            }

            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }


        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }


        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

     
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }
       
    }
}

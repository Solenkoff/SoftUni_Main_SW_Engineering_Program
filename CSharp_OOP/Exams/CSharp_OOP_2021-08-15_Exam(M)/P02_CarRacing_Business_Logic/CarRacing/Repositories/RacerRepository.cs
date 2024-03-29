﻿namespace CarRacing.Repositories
{
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RacerRepository : IRepository<IRacer>
    {

        private readonly ICollection<IRacer> models;

        public RacerRepository()
        {
            this.models = new HashSet<IRacer>();
        }


        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>)this.models;


        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }

        public IRacer FindBy(string property)
        {
            return this.models.FirstOrDefault(c => c.Username == property);
        }

        
    }
}

﻿namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IList<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models
            => (IReadOnlyCollection<IAstronaut>)this.astronauts;

        public void Add(IAstronaut model)
            => this.astronauts.Add(model);

        public IAstronaut FindByName(string name)
            => this.astronauts.FirstOrDefault(a => a.Name == name);

        public bool Remove(IAstronaut model)
            => this.astronauts.Remove(model);
    }
}

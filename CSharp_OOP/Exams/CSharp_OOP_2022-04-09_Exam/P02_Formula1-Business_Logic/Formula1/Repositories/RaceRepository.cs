namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> races;

        public RaceRepository()
        {
            this.races = new HashSet<IRace>();
        }


        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)this.races;

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }

        public IRace FindByName(string name)
        {
            return this.races.FirstOrDefault(c => c.RaceName == name);
        }

    }
}

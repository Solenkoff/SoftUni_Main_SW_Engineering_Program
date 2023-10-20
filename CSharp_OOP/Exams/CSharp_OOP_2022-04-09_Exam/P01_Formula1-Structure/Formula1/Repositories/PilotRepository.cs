namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> pilots;

        public PilotRepository()
        {
            this.pilots = new HashSet<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)this.pilots;

        public void Add(IPilot model)
        {
            this.pilots.Add(model);
        }

        public bool Remove(IPilot model)
        {
            return this.pilots.Remove(model);
        }

        public IPilot FindByName(string name)
        {
            return this.pilots.FirstOrDefault(c => c.FullName == name);
        }

       
    }
}

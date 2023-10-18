namespace NavalVessels.Repositories
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VesselRepository : IRepository<IVessel>
    {
        private ICollection<IVessel> vessels;

        public VesselRepository()
        {
            this.vessels = new HashSet<IVessel>();
        }


        public IReadOnlyCollection<IVessel> Models => (IReadOnlyCollection<IVessel>)this.vessels;

        public void Add(IVessel model)
        {
            this.vessels.Add(model);
        }

        public bool Remove(IVessel model)
        {
            return this.vessels.Remove(model);
        }

        public IVessel FindByName(string name)
        {
            return this.vessels.FirstOrDefault(v => v.Name == name);
        }

       
    }
}

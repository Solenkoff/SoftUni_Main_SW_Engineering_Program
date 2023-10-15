namespace Gym.Repositories
{
    using Models.Equipment.Contracts;
    using Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class EquipmentRepository : IRepository<IEquipment>
    {

        private ICollection<IEquipment> models;

        public EquipmentRepository()
        {
            this.models = new HashSet<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => (IReadOnlyCollection<IEquipment>)this.models;

        public void Add(IEquipment model)
        {
            this.models.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return this.models.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.models.FirstOrDefault(m => m.GetType().Name == type);
        }
      
    }
}

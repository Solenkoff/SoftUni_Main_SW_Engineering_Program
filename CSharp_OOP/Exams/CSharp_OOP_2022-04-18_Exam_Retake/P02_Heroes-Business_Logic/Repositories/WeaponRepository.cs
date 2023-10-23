namespace Heroes.Repositories
{
    using Models.Contracts;
    using Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository<IWeapon>
    {

        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }


        public IReadOnlyCollection<IWeapon> Models => this.weapons.AsReadOnly();


        public void Add(IWeapon model)
        {
            this.weapons.Add(model);
        }
      
        public bool Remove(IWeapon model)
        {
            return weapons.Remove(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.weapons.FirstOrDefault(h => h.Name == name);
        }

    }
}

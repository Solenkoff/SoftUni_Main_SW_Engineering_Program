namespace Heroes.Repositories
{
    using Models.Contracts;
    using Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WeaponRepository : IRepository<IWeapon>
    {

        private readonly Dictionary<string, IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
        }


        public IReadOnlyCollection<IWeapon> Models => this.weapons.Values;


        public void Add(IWeapon model)
        {
            this.weapons.Add(model.Name, model);
        }
      
        public bool Remove(IWeapon model)
        {
            return weapons.Remove(model.Name);
        }

        public IWeapon FindByName(string name)
        {
            if (weapons.ContainsKey(name))
            {
                return weapons[name];
            }

            return null;
        }

    }
}

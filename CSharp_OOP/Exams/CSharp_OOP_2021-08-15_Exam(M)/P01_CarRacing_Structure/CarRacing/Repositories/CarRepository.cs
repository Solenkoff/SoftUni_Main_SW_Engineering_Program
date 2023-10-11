namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> models;

        public CarRepository()
        {
            this.models = new HashSet<ICar>();
        }


        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)this.models;


        public void Add(ICar model)
        {
            if(model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }

        public ICar FindBy(string property)
        {
            return this.models.FirstOrDefault(c => c.VIN == property);
        }

       
    }
}

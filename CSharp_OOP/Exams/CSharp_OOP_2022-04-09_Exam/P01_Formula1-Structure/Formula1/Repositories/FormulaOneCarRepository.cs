namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            this.cars = new HashSet<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)this.cars;

        public void Add(IFormulaOneCar model)
        {

            this.cars.Add(model);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.cars.Remove(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.cars.FirstOrDefault(c => c.Model == name);
        }

       
    }
}

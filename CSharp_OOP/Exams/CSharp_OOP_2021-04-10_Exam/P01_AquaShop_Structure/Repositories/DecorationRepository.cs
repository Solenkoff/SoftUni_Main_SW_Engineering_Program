namespace AquaShop.Repositories
{
    using Models.Decorations.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }


        public IReadOnlyCollection<IDecoration> Models => this.decorations.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }


        public bool Remove(IDecoration model)
        {
            return this.decorations.Remove(model);
        }


        public IDecoration FindByType(string type)
        {
            return this.decorations.FirstOrDefault(d => d.GetType().Name == type);   //  !!!   NULL  !!!
        }

    }
}

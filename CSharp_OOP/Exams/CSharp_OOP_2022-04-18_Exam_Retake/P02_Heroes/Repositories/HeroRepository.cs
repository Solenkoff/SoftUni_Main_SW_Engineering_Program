namespace Heroes.Repositories
{
    using Models.Contracts;
    using Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class HeroRepository : IRepository<IHero>
    {

        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.heroes.AsReadOnly();


        public void Add(IHero model)
        {
            this.heroes.Add(model);
        }
      
        public bool Remove(IHero model)
        {
            return heroes.Remove(model);
        }

        public IHero FindByName(string name)
        {
            return this.heroes.FirstOrDefault(h => h.Name == name);
        }

    }
}

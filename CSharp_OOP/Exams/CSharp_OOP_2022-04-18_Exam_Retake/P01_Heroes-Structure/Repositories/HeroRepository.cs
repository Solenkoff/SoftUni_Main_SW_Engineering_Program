namespace Heroes.Repositories
{
    using Models.Contracts;
    using Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class HeroRepository : IRepository<IHero>
    {

        private readonly Dictionary<string, IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new Dictionary<string, IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.heroes.Values;


        public void Add(IHero model)
        {
            this.heroes.Add(model.Name, model);
        }
      
        public bool Remove(IHero model)
        {
            return heroes.Remove(model.Name);
        }

        public IHero FindByName(string name)
        {
            if (heroes.ContainsKey(name))
            {
                return heroes[name];
            }

            return null;
        }

    }
}

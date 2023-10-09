namespace Easter.Core
{
    using Easter.Core.Contracts;
    using Easter.Models.Bunnies;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes;
    using Easter.Models.Dyes.Contracts;
    using Easter.Models.Eggs;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops;
    using Easter.Repositories;
    using Easter.Repositories.Contracts;
    using Easter.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunnies;
        private readonly IRepository<IEgg> eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = bunnyType switch
            { 
                nameof(HappyBunny) => new HappyBunny(bunnyName),
                nameof(SleepyBunny) => new SleepyBunny(bunnyName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType)
            };

            this.bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = this.eggs.FindByName(eggName);

            var suitableBunnies = this.bunnies.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToArray();
            if(suitableBunnies.Length == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            Workshop shop = new Workshop();

            foreach (var bunny in suitableBunnies)
            {
                shop.Color(egg, bunny);
                if(bunny.Energy == 0)
                {
                    this.bunnies.Remove(bunny);
                }
                if (egg.IsDone())
                {
                    break;
                }
            }

            return egg.IsDone() ? string.Format(OutputMessages.EggIsDone, eggName) 
                                : string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            int eggsDone = this.eggs.Models.Where(e => e.IsDone()).Count();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{eggsDone} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in this.bunnies.Models)
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

namespace Easter.Models.Workshops
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Color(IEgg egg, IBunny bunny)
        {
            if (bunny.Energy > 0 && bunny.Dyes.Any(d => !d.IsFinished()))
            {
                return;
            }


            foreach (var dye in bunny.Dyes.Where(d => !d.IsFinished()))
            {
                egg.GetColored();
                bunny.Work();
                dye.Use();

                if (egg.IsDone() || bunny.Energy == 0 && bunny.Dyes.All(d => d.IsFinished()))
                {
                    break;
                }
            }

        }
    }
}

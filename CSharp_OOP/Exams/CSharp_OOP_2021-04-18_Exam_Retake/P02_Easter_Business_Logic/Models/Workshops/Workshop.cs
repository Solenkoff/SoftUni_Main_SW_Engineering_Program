namespace Easter.Models.Workshops
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
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

            while (bunny.Energy > 0 && bunny.Dyes.Any(d => !d.IsFinished()))
            {
                foreach (var dye in bunny.Dyes.Where(d => !d.IsFinished()))
                {
                    while (!dye.IsFinished())
                    {
                        egg.GetColored();
                        bunny.Work();
                        dye.Use();

                        if (egg.IsDone() || bunny.Energy == 0)
                        {
                            return;
                        }
                    }
                }
            }


            //while (!egg.IsDone() && bunny.Energy > 0)
            //{
            //    IDye currentDye = bunny.Dyes.FirstOrDefault(x => !x.IsFinished());

            //    if (currentDye == null)
            //    {
            //        break;
            //    }

            //    while (bunny.Energy > 0 && currentDye.Power > 0)
            //    {
            //        bunny.Work();
            //        currentDye.Use();
            //        egg.GetColored();

            //        if (egg.IsDone())
            //        {
            //            break;
            //        }
            //    }
            //}

        }
    }
}

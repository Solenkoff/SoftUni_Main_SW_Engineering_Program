namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Submarine : Vessel
    {
        private const double InitialArmourThickness = 200;
        private bool submergeMode;


        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmourThickness)
        {
            this.SubmergeMode = false;
        }


        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
                this.SubmergeMode = false;
            }
            else
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
                this.SubmergeMode = true;
            }
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmourThickness;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (this.SubmergeMode)
            {
                sb.AppendLine(" *Submerge mode: ON");
            }
            else
            {
                sb.AppendLine(" *Submerge mode: OFF");
            }

            return sb.ToString().Trim();
        }

    }
}

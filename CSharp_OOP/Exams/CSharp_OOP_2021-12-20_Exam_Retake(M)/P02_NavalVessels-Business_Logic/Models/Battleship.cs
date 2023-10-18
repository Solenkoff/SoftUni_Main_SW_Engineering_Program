namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Battleship : Vessel
    {
        private const double InitialArmourThickness = 300;
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmourThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode  { get; private set; }


        public void ToggleSonarMode()
        {
            if (this.SonarMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                this.SonarMode = false;
            }
            else
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
                this.SonarMode = true;
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

            if (this.SonarMode)
            {
                sb.AppendLine(" *Sonar mode: ON");
            }
            else
            {
                sb.AppendLine(" *Sonar mode: OFF");
            }

            return sb.ToString().Trim();
        }

    }
}

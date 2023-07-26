using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        
        public double SurfaceArea(Box box)
        { 
            double surfaceArea = 0;
            surfaceArea = 2 * (this.length * this.height + this.width * this.height
                             + this.length * this.width);

            return surfaceArea;
        }


        public double LateralSurface(Box box)
        {
            double lateralSurface = 0;
            lateralSurface = 2 * (this.length * this.height + width * this.height);

            return lateralSurface;
        }


        public double Volume(Box box)
        {
            double volume = 0;
            volume = this.Length * this.Width * this.Height;

            return volume;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea(this):f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurface(this):f2}");
            sb.AppendLine($"Volume - {Volume(this):f2}");

            return sb.ToString().Trim();
        }

    }
}

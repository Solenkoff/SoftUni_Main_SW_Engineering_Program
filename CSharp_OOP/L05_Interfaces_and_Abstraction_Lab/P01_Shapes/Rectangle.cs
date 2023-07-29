using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int height;

        private int width;

        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height
        {
            get => this.height;
            set => this.height = value;
        }
        public int Width
        {
            get => this.width;
            set => this.width = value;
        }

        public void Draw()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}

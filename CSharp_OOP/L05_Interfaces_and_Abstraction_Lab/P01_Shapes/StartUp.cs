using System;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IDrawable> drawableObjects = new List<IDrawable>();

            drawableObjects.Add(new Rectangle(4, 6));
            drawableObjects.Add(new Circle(7));


            foreach (var item in drawableObjects)
            {
                item.Draw();
            }

           
        }
    }
}

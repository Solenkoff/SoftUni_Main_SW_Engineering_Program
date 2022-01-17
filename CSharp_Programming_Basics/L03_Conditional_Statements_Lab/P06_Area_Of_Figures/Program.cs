using System;

namespace _06_Area_Of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;

            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                area = side * side;
            }
            else if (figure == "rectangle")
            {
                double side1 = double.Parse(Console.ReadLine());
                double side2 = double.Parse(Console.ReadLine());
                area = side1 * side2;
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                area = Math.PI * (radius * radius);
            }
            else if (figure == "triangle")
            {
                double side1 = double.Parse(Console.ReadLine());
                double side2 = double.Parse(Console.ReadLine());
                area = (side1 * side2) / 2;
            }
            Console.WriteLine($"{area:f3}");
        }
    }
}

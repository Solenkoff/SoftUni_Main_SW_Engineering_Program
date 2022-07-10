using System;

namespace _06_Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {

            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = PrintArea(width, height);
            Console.WriteLine(area);

        }


        static double PrintArea(double width, double height)
        {
            return width * height;
        }

    }
}

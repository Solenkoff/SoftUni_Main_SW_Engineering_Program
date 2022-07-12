using System;

namespace _08_Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {

            double num = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = RaiseToPower(num, power);
            Console.WriteLine(result);

        }

        private static double RaiseToPower(double num, int power)
        {
            double result = 0d;
            result = Math.Pow(num, power);

            return result;
        }

    }
}

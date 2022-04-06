using System;

namespace _09_Padawan_Equipment_
{
    class Program
    {
        static void Main(string[] args)
        {

            double budget = double.Parse(Console.ReadLine());
            int nStudents = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double lightsabersCost = Math.Ceiling(nStudents * 1.10) * lightsabersPrice;
            double robesCost = nStudents * robesPrice;
            double beltsCost = (nStudents * beltsPrice) - (nStudents / 6 * beltsPrice);

            double totalCost = lightsabersCost + robesCost + beltsCost;

            if (totalCost <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalCost - budget:f2}lv more.");
            }

        }
    }
}

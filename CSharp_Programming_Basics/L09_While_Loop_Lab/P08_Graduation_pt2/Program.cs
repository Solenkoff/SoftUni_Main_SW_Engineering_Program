using System;

namespace _08_Graduation_pt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grades = 1;
            double sum = 0;
            int excluded = 0;
            while (grades <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    excluded++;
                    if (excluded > 1)
                    {
                        break;
                    }
                }
                if (grade >= 4)
                {
                    sum = sum + grade;
                    grades++;
                }
            }
            if (grades > 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {sum / 12:f2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {grades} grade");
            }
        }
    }
}

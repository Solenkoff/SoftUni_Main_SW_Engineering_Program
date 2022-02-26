using System;

namespace _02_Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorGrades = int.Parse(Console.ReadLine());
            string task = Console.ReadLine();
            int poorGradeCount = 0;
            int gradeCount = 0;
            int score = 0;
            string lastProblem = "";
            bool isPerfect = true;

            while (task != "Enough")
            {
                lastProblem = task;
                int grade = int.Parse(Console.ReadLine());
                gradeCount++;
                score += grade;
                if (grade <= 4)
                {
                    poorGradeCount++;
                    if (poorGradeCount >= poorGrades)
                    {
                        isPerfect = false;
                        break;
                    }
                }
                task = Console.ReadLine();
            }
            double averageSum = 1.0 * score / gradeCount;
            if (isPerfect)
            {
                Console.WriteLine($"Average score: {averageSum:f2}");
                Console.WriteLine($"Number of problems: {gradeCount}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
            else
            {
                Console.WriteLine($"You need a break, {poorGradeCount} poor grades.");
            }
        }
    }
}

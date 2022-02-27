using System;

namespace _04_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = 10000;
            int totalSteps = 0;
            while (totalSteps < target)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    int leftSteps = int.Parse(Console.ReadLine());
                    totalSteps += leftSteps;
                    break;
                }
                else
                {
                    int steps = int.Parse(input);
                    totalSteps += steps;
                }
            }
            if (totalSteps >= target)
            {
                int stepsOver = totalSteps - target;
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsOver} steps over the goal!");
            }
            else
            {
                int moreStesneeded = target - totalSteps;
                Console.WriteLine($"{moreStesneeded} more steps to reach goal.");
            }
        }
    }
}

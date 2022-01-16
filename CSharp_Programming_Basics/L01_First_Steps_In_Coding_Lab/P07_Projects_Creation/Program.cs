using System;

namespace _07_Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string architecterNamename = Console.ReadLine();
            int projectNim = int.Parse(Console.ReadLine());
            int projectperhour = 3;
            int neededTime = projectNim * projectperhour;

            Console.WriteLine($"The architect {architecterNamename} will need {neededTime} hours to complete {projectNim} project/s.");
        }
    }
}

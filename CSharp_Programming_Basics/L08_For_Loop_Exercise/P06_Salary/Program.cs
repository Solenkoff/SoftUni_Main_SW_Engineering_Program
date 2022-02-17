using System;

namespace _06_Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int openBrowsers = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());


            for (int i = 0; i <= openBrowsers; i++)
            {
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
                string browsers = Console.ReadLine();
                if (browsers == "Facebook")
                {
                    salary -= 150;
                }
                else if (browsers == "Instagram")
                {
                    salary -= 100;
                }
                else if (browsers == "Reddit")
                {
                    salary -= 50;
                }
            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}

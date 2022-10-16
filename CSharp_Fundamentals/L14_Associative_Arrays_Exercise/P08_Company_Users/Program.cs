using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputData = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string companyName = inputData[0];
                string employeeID = inputData[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());

                }
                if (!companies[companyName].Contains(employeeID))
                {
                    companies[companyName].Add(employeeID);
                }

                input = Console.ReadLine();
            }


            foreach (var company in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{company.Key}");
                foreach (var emploee in company.Value)
                {
                    Console.WriteLine($"-- {emploee}");
                }
            }

        }
    }
}

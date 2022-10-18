using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_SoftUni_Exam_Results_
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<int>> submissionsByStudent = new Dictionary<string, List<int>>();
            Dictionary<string, int> submissionsByLanguage = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] submissionsData = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                if (submissionsData.Length == 2)
                {
                    string userName = submissionsData[0];
                    if (submissionsByStudent.ContainsKey(userName))
                    {
                        submissionsByStudent.Remove(userName);
                    }

                }
                else
                {
                    string userName = submissionsData[0];
                    string language = submissionsData[1];
                    int curSubmissionPoints = int.Parse(submissionsData[2]);

                    if (submissionsByStudent.ContainsKey(userName))
                    {
                        submissionsByStudent[userName].Add(curSubmissionPoints);
                        if (submissionsByLanguage.ContainsKey(language))
                        {
                            submissionsByLanguage[language]++;
                        }
                        else
                        {
                            submissionsByLanguage.Add(language, 1);
                        }
                    }
                    else
                    {
                        submissionsByStudent.Add(userName, new List<int> { curSubmissionPoints });
                        if (submissionsByLanguage.ContainsKey(language))
                        {
                            submissionsByLanguage[language]++;
                        }
                        else
                        {
                            submissionsByLanguage.Add(language, 1);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var userName in submissionsByStudent.OrderByDescending(x => x.Value.Max()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{userName.Key} | {userName.Value.Max()}");
            }

            Console.WriteLine("Submissions:");

            foreach (var language in submissionsByLanguage.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Courses
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] coursesData = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string courseName = coursesData[0];
                string studentName = coursesData[1];

                if (courses.ContainsKey(courseName))
                {
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses.Add(courseName, new List<string> { studentName });
                }

                input = Console.ReadLine();
            }

            foreach (var course in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var item in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }

        }
    }
}

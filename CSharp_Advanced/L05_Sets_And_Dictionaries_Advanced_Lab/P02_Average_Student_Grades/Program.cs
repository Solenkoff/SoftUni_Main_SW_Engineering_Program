using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            int numStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numStudents; i++)
            {
                string[] studentsData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = studentsData[0];
                decimal grade = decimal.Parse(studentsData[1]);

                if(!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }

                students[name].Add(grade);
            }

            foreach (var student in students)
            {             
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }

        }
    }
}

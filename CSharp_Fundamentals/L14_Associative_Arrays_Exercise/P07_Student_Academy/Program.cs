using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {

            int nInputs = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < nInputs; i++)
            {

                string studentsName = Console.ReadLine();
                double studentsGrade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(studentsName))
                {
                    students[studentsName].Add(studentsGrade);
                }
                else
                {
                    students.Add(studentsName, new List<double> { studentsGrade });
                }
            }

            foreach (var student in students.Where(x => x.Value.Average() < 4.50))
            {
                students.Remove(student.Key);
            }

            foreach (var student in students.OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }

        }
    }
}

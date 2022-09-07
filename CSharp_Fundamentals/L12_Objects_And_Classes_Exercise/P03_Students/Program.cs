using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Students
{
    class Program
    {
        static void Main(string[] args)
        {

            int nStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < nStudents; i++)
            {
                string[] info = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = info[0];
                string secondName = info[1];
                double grade = double.Parse(info[2]);

                Student student = new Student(firstName, secondName, grade);
                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();


            Console.WriteLine(string.Join(Environment.NewLine, students));

        }
    }

    class Student
    {
        public Student(string firstName, string secondName, double grade)
        {
            FirstName = firstName;
            SecondName = secondName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:f2}";
        }
    }

}

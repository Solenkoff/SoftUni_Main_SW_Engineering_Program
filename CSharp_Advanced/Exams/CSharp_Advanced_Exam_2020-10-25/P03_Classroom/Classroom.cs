using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get { return students.Count; }  }


        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                students.Add(student);
               
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }


        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student == null)
            {
                return "Student not found";

            }
            else
            {
                this.students.Remove(student);
                
                return $"Dismissed student {firstName} {lastName}";
            }
        }

        public string GetSubjectInfo(string subject)
        {

            List<Student> sameObjectStudents = students.FindAll(x => x.Subject == subject);
            
            if (sameObjectStudents.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in sameObjectStudents)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }


        public int GetStudentsCount()
        {
            return this.Count;
        }


        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            return student;
        }
    }
}

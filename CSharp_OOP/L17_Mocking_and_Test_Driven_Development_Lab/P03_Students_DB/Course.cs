using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsDB
{
    public class Course
    {

        private IDatabase database;

        public Course(IDatabase db)
        {
            this.database = db;
        }
        public void SignStudent(int studentId)
        {
            Student student = database.GetStudentById(studentId);
        }

        public void RegisterStudent(Student student)
        {
             
        }

        public void DisplayAllStudents()
        {
            foreach (var student in database.GetAllstudents())
            {
                Console.WriteLine(student);
            }
        }
    }
}

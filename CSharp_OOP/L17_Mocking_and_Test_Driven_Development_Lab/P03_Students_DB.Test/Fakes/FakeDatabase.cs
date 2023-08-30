using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsDB.Test.Fakes
{
    public class FakeDatabase : IDatabase
    {
        public IEnumerable<Student> GetAllstudents()
        {
            return new Student[] { new Student(1, "Pesho"), new Student(2, "Gosho"), new Student(3, "Tosho") };
        }

        public Student GetStudentById(int id)
        {
            return new Student(1, "Gosheto");
        }

        public void UpdateStudent(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}

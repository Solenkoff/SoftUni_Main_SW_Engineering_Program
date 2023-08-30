using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsDB
{
    public interface IDatabase
    {

       int Capacity { get; set; }
        IEnumerable<Student> GetAllstudents();

        Student GetStudentById(int id);

        void UpdateStudent(int id, Student student);

    }
}

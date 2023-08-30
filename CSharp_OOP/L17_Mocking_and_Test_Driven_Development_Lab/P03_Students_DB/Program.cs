using Moq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentsDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Mock<IDatabase> mockDb = new Mock<IDatabase>();

            mockDb.Setup(d => d.Capacity).Returns(42);

            Console.WriteLine($"Capacity: {mockDb.Object.Capacity}");

            mockDb.Setup(d => d.GetStudentById(It.IsAny<int>()))
                  .Callback(() =>
                  {
                      Console.WriteLine("Get student called!!!");
                  })
                  .Returns(() => new Student(5, "Pesho"));

            mockDb.Setup(d => d.GetStudentById(2))
                  .Callback(() =>
                  {
                      Console.WriteLine("Get student called with param 2");
                  })
                  .Returns(() => new Student(2, "Gogi"));

            DbUser dbUser = new DbUser(mockDb.Object);

            Student student = dbUser.GetStudentById(5);

            Student student2 = dbUser.GetStudentById(2);
        }
    }


    class DbUser
    {
        public DbUser(IDatabase db)
        {
            this.Db = db;
            IEnumerable<Student> students = db.GetAllstudents();

            foreach (var student in db.GetAllstudents())
            {
                Console.WriteLine(student.Name);
            }
        }


        public IDatabase Db { get; set; }

        public Student GetStudentById(int id)
        {
            Student student = Db.GetStudentById(id);
            return student;
        }

    }

}

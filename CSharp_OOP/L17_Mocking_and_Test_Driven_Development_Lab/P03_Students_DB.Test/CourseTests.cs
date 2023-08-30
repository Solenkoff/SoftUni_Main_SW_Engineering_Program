using NUnit.Framework;
using StudentsDB.Test.Fakes;
using System;

namespace StudentsDB.Test
{

    [TestFixture]
    public class CourseTests
    {

        [Test]
        public void When_DisplayAllStudentsIsCalled_ShouldDisplayAll()
        {
            Course course = new Course(new FakeDatabase());

            course.DisplayAllStudents();

            course.SignStudent(1);
        }
    }
}

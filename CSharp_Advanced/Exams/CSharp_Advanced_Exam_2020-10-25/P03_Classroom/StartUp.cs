namespace ClassroomProject
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Initialize the repository
            Classroom classroom = new Classroom(10);
            // Initialize entities
            Student student = new Student("Peter", "Parker", "Geometry");
            Student studentTwo = new Student("Sarah", "Smith", "Algebra");
            Student studentThree = new Student("Sam", "Winchester", "Algebra");
            Student studentFour = new Student("Dean", "Winchester", "Music");
            // Print Student
            Console.WriteLine(student); // Student: First Name = Peter, Last Name = Parker, Subject = Geometry
                                        // Register Student
            string register = classroom.RegisterStudent(student);
            Console.WriteLine(register); // Added student Peter Parker
            string registerTwo = classroom.RegisterStudent(studentTwo);
            string registerThree = classroom.RegisterStudent(studentThree);
            string registerFour = classroom.RegisterStudent(studentFour);
            // Dismiss Student
            string dismissed = classroom.DismissStudent("Peter", "Parker");
            Console.WriteLine(dismissed); // Dismissed student Peter Parker
            string dismissedTwo = classroom.DismissStudent("Ellie", "Goulding");
            Console.WriteLine(dismissedTwo); // Student not found
                                             // Subject info
            string subjectInfo = classroom.GetSubjectInfo("Algebra");
            Console.WriteLine(subjectInfo);
            // Subject: Algebra
            // Students:
            // Sarah Smith
            // Sam Winchester
            string anotherInfo = classroom.GetSubjectInfo("Art");
            Console.WriteLine(anotherInfo); // No students enrolled for the subject
                                            // Get Student
            Console.WriteLine(classroom.GetStudent("Dean", "Winchester"));
            // Student: First Name = Dean, Last Name = Winchester, Subject = Music



            //Classroom classroom = new Classroom(3);

            //Student student1 = new Student("Gogo", "Nachev", "history");
            //Student student2 = new Student("Pesho", "Peshov", "history");
            //Student student3 = new Student("Kunio", "Lilov", "math");
            //Student student4 = new Student("Vili", "Dikov", "history");



            //Console.WriteLine(student1);

            //classroom.RegisterStudent(student1);
            //classroom.RegisterStudent(student2);
            //classroom.RegisterStudent(student3);
            //classroom.RegisterStudent(student4);


            //Console.WriteLine(classroom.GetStudent("Gogo", "Nachev"));

            //Console.WriteLine(classroom.GetSubjectInfo("bobo"));

            //string dismissed = classroom.DismissStudent("Gogo", "Nachev");
            //Console.WriteLine(dismissed);
            //Console.WriteLine(classroom.GetStudentsCount());
        }
    }
}
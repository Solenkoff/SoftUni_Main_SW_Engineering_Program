namespace P09_Employee_147
{
    using SoftUni.Data;
    using System.Text;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetEmployee147(context));
        }

        public static string GetEmployee147(SoftUniContext context)    
        {
            var employee147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name
                    })
                   .OrderBy(p => p.ProjectName)
                   .ToArray()
                }).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee147[0].FirstName} {employee147[0].LastName} - {employee147[0].JobTitle}");

            foreach (var project in employee147[0].Projects)
            {
                sb.AppendLine($"{project.ProjectName}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
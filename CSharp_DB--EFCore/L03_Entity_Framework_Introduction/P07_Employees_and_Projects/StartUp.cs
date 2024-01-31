namespace P07_Employees_and_Projects
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using System.Globalization;
    using System.Text;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetEmployeesInPeriod(context));
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)    //  P_07
        {
            var employees = context.Employees
               .Include(x => x.EmployeesProjects)
               .ThenInclude(x => x.Project)
               //   .Where(x => x.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && 
               //                                             ep.Project.StartDate.Year <= 2003))
               .Select(e => new
               {
                   EmployeeFirstName = e.FirstName,
                   EmployeeLastName = e.LastName,
                   ManagerFirstName = e.Manager.FirstName,
                   ManagerLastName = e.Manager.LastName,
                   Projects = e.EmployeesProjects.Select(ep => new
                   {
                       ProjectName = ep.Project.Name,
                       StartDate = ep.Project.StartDate,
                       EndDate = ep.Project.EndDate
                   })
                   .Where(p => (p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
               })
               .Take(10)
               .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    var endDate = project.EndDate.HasValue
                        ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");

                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}
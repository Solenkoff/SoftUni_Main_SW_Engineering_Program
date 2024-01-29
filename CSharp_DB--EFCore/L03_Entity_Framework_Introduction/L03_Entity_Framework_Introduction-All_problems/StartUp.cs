namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualBasic;
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            //Console.WriteLine(GetEmployeesFullInformation(context));              //  P_03
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));          //  P_04
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));   //  P_05
            //Console.WriteLine(AddNewAddressToEmployee(context));                  //  P_06
            //Console.WriteLine(GetEmployeesInPeriod(context));                     //  P_07
            //Console.WriteLine(GetAddressesByTown(context));                       //  P_08
            //Console.WriteLine(GetEmployee147(context));                           //  P_09
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));     //  P_10
            //Console.WriteLine(GetLatestProjects(context));                        //  P_11
            //Console.WriteLine(IncreaseSalaries(context));                         //  P_12
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));    //  P_13
            //Console.WriteLine(DeleteProjectById(context));                        //  P_14
            //Console.WriteLine(RemoveTown(context));                               //  P_15

        }


        public static string GetEmployeesFullInformation(SoftUniContext context)   //  P_03
        {
            var employees = context
                .Employees
                .Select(e => new { 
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            string result = String.Join(Environment.NewLine, 
                employees.Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"));

            return result;
        }


        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)   //  P_04
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            string result = string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} - {e.Salary:f2}"));

            return result;
        }


        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)    //  P_05
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            string result = string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}"));

            return result;
        }


        public static string AddNewAddressToEmployee(SoftUniContext context)    //  P_06
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId =  4
            };

            var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = address;

            context.SaveChanges();

            var employees = context.Employees
                .Select(e => new {
                    e.Address.AddressText,
                    e.AddressId
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, employees.Select(e => $"{e.AddressText}"));
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


        public static string GetAddressesByTown(SoftUniContext context)    //  P_08
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(e => e.EmployeeCount)
                .ThenBy(e => e.TownName)
                .ThenBy(e => e.AddressText)
                .Take(10)
                .ToArray();

            return string.Join(Environment.NewLine, addresses
                         .Select(a => $"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees"));
        }


        public static string GetEmployee147(SoftUniContext context)     //  P09
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


        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)   //  P_10
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                { 
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                       {
                          e.FirstName,
                          e.LastName,
                          e.JobTitle
                       })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                })
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();


            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetLatestProjects(SoftUniContext context)    //  P_11
        {
            var last10Projects = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var project in last10Projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }


        public static string IncreaseSalaries(SoftUniContext context)     //  P_12
        {
            var departments = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(e => departments.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();
                
            foreach (var emp in employees)
            {
                emp.Salary *= (decimal)1.12;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }



        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)   //  P_13
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            string result = string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})"));

            return result;
        }


        public static string DeleteProjectById(SoftUniContext context)   //  P_14
        {
            var projectToDelete = context.Projects.FirstOrDefault(p => p.ProjectId == 2);

            var connectedProjects = context.EmployeesProjects.Where(ep => ep.ProjectId == 2).ToList();

            foreach (var p in connectedProjects)
            {
                context.EmployeesProjects.Remove(p);
            }

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();  

            var projects = context.Projects
                .Select(p => new 
                {
                    p.Name 
                })
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, projects.Select(p => p.Name));
        }


        public static string RemoveTown(SoftUniContext context)        //  P_15
        {
            var town = context.Towns
                .Include(t => t.Addresses)
                .FirstOrDefault(t => t.Name == "Seattle");

            int result = 0;

            if(town != null)
            {
                var employees = context.Employees
                       .Where(e => e.AddressId.HasValue && e.Address.TownId == town.TownId);

                foreach (var emp in employees)
                {
                    emp.AddressId = null;
                }

                context.Addresses.RemoveRange(town.Addresses);
                context.Towns.Remove(town);

                context.SaveChanges();

                result = town.Addresses.Count;
            }

            return $"{result} addresses in Seattle were deleted";

        }

    }

}
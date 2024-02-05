namespace P12_Increase_Salaries
{
    using SoftUni.Data;
    using System.Text;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(IncreaseSalaries(context));
        }

        public static string IncreaseSalaries(SoftUniContext context)     
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
    }
}
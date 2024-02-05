namespace P13_Find_Employees_by_First_Name_Starting_With_Sa
{
    using SoftUni.Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)   
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
    }
}
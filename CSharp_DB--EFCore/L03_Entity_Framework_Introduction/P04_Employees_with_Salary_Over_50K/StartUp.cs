namespace P04_Employees_with_Salary_Over_50K
{
    using SoftUni.Data;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)   
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
    }
}
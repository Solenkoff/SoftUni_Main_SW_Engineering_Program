namespace P11_Find_Latest_10_Projects
{
    using SoftUni.Data;
    using System.Globalization;
    using System.Text;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetLatestProjects(context));
        }

        public static string GetLatestProjects(SoftUniContext context)   
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
    }
}
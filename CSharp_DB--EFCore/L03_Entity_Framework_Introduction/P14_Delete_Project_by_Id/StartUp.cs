namespace P14_Delete_Project_by_Id
{
    using SoftUni.Data;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(DeleteProjectById(context));
        }

        public static string DeleteProjectById(SoftUniContext context)  
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
    }
}
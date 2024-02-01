namespace P08_Addresses_by_Town
{
    using SoftUni.Data;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetAddressesByTown(context));
        }

        public static string GetAddressesByTown(SoftUniContext context)    
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

    }
}
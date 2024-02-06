namespace P15_Remove_Town
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(RemoveTown(context));
        }

        public static string RemoveTown(SoftUniContext context)        
        {
            var town = context.Towns
                .Include(t => t.Addresses)
                .FirstOrDefault(t => t.Name == "Seattle");

            int result = 0;

            if (town != null)
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
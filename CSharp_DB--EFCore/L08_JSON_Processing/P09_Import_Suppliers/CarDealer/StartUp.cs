namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using Castle.Core.Resource;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");   // P09
            Console.WriteLine(ImportSuppliers(context, suppliersJson));

        }


        public static string ImportSuppliers(CarDealerContext context, string inputJson)   // P09
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            SupplierDTO[] supplierDTOs = JsonConvert.DeserializeObject<SupplierDTO[]>(inputJson);
            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDTOs);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

    }
}
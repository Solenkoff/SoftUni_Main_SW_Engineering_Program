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

            string customersJson = File.ReadAllText("../../../Datasets/customers.json");    // P12
            Console.WriteLine(ImportCustomers(context, customersJson));

        }


        public static string ImportCustomers(CarDealerContext context, string inputJson)    // P12
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            CustomerDTO[] customerDTOs = JsonConvert.DeserializeObject<CustomerDTO[]>(inputJson);
            Customer[] customers = mapper.Map<Customer[]>(customerDTOs);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";

        }

    }
}
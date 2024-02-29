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

            string salesJson = File.ReadAllText("../../../Datasets/sales.json");           // P13
            Console.WriteLine(ImportSales(context, salesJson));

        }


        public static string ImportSales(CarDealerContext context, string inputJson)    // P13
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            SaleDTO[] saleDTOs = JsonConvert.DeserializeObject<SaleDTO[]>(inputJson);
            Sale[] sales = mapper.Map<Sale[]>(saleDTOs);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";

        }

    }
}
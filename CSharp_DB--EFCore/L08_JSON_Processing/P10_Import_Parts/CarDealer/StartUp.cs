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

            string partsJson = File.ReadAllText("../../../Datasets/parts.json");           // P10
            Console.WriteLine(ImportParts(context, partsJson));

        }


        public static string ImportParts(CarDealerContext context, string inputJson)     // P10
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            PartsDTO[] partDTOs = JsonConvert.DeserializeObject<PartsDTO[]>(inputJson);

            int[] supplierIDs = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            Part[] parts = mapper.Map<Part[]>(partDTOs)
                .Where(p => supplierIDs.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";

        }

    }
}
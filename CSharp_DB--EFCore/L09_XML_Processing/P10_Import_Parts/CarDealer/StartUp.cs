namespace CarDealer
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Data;
    using CarDealer.DTOs.Export;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {

            CarDealerContext context = new CarDealerContext();

            var inputPartsXml = File.ReadAllText("../../../Datasets/parts.xml");           // P10
            Console.WriteLine(ImportParts(context, inputPartsXml));

        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string ImportParts(CarDealerContext context, string inputXml)        // P10
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            using var reader = new StringReader(inputXml);
            ImportPartDto[] importPartDtos = (ImportPartDto[])xmlSerializer.Deserialize(reader);

            var existingSupplierIDs = context.Suppliers
                .Select(s => s.Id)
                .ToArray();
            var partsWithExistingSupplier = importPartDtos
                .Where(p => existingSupplierIDs.Contains(p.SupplierId));

            var mapper = GetMapper();
            Part[] parts = mapper.Map<Part[]>(partsWithExistingSupplier);

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {partsWithExistingSupplier.Count()}";

        }
    }
}
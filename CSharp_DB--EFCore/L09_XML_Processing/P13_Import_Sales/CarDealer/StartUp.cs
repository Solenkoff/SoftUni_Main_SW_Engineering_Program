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

            var inputSalesXml = File.ReadAllText("../../../Datasets/sales.xml");           // P13
            Console.WriteLine(ImportSales(context, inputSalesXml));

        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }


        public static string ImportSales(CarDealerContext context, string inputXml)         // 13
        {
            XmlSerializer xmlSerializer =
              new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            using var reader = new StringReader(inputXml);
            ImportSaleDto[] importSaleDtos = (ImportSaleDto[])xmlSerializer.Deserialize(reader);

            var existingCarIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            var mapper = GetMapper();

            Sale[] sales = mapper.Map<Sale[]>(importSaleDtos
                                 .Where(s => existingCarIds.Contains(s.CarId)));

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

    }
}
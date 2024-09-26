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

            Console.WriteLine(GetCarsWithTheirListOfParts(context));                       // P17

        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)        // P17
        {
            var mapper = GetMapper();

            var allCarsWithParts = context.Cars
                .Select(c => new ExportAllCarsWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars.Select(pc => new ExportPartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(pc => pc.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer =
           new XmlSerializer(typeof(ExportAllCarsWithPartsDto[]), new XmlRootAttribute("cars"));

            var nsXml = new XmlSerializerNamespaces();
            nsXml.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, allCarsWithParts, nsXml);
            }

            return sb.ToString().TrimEnd();

        }
    }
}
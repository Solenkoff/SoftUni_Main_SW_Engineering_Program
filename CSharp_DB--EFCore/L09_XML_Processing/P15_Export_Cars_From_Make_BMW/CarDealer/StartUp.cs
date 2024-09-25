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

            Console.WriteLine(GetCarsFromMakeBmw(context));                                // P15

        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }


        public static string GetCarsFromMakeBmw(CarDealerContext context)          // P15
        {
            var mapper = GetMapper();

            var carsBMW = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportBMWCarDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            XmlSerializer xmlSerializer =
           new XmlSerializer(typeof(ExportBMWCarDto[]), new XmlRootAttribute("cars"));

            var nsXml = new XmlSerializerNamespaces();
            nsXml.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, carsBMW, nsXml);
            }

            return sb.ToString().TrimEnd();

        }
    }
}
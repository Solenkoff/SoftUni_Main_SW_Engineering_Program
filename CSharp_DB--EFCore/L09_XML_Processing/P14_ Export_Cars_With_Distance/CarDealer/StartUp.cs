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

            Console.WriteLine(GetCarsWithDistance(context));                               // P14

        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }


        public static string GetCarsWithDistance(CarDealerContext context)          // P14
        {
            var mapper = GetMapper();

            //var cars = context.Cars
            //    .Where(c => c.TraveledDistance > 2000000)
            //    .OrderBy(c => c.Make)
            //    .ThenBy(c => c.Model)
            //    .Select(c => new Dictionary<string, object>
            //    {
            //        { "make" , c.Make },
            //        { "model" , c.Model},
            //        { "traveled-distance" , c.TraveledDistance}
            //    })
            //    .Take(10)
            //    .ToArray();

            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDistanceDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer xmlSerializer =
             new XmlSerializer(typeof(ExportCarDistanceDto[]), new XmlRootAttribute("cars"));

            var nsXml = new XmlSerializerNamespaces();
            nsXml.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, cars, nsXml);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
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

            Console.WriteLine(GetSalesWithAppliedDiscount(context));                       // P19

        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }


        public static string GetSalesWithAppliedDiscount(CarDealerContext context)        // P19
        {
            var mapper = GetMapper();
           
            var sales = context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Car.PartsCars)
                .ThenInclude(pc => pc.Part)
                .AsEnumerable()
                .Select(s => new ExportAllSalesDto
                {
                    Car = new ExportCarOfSaleDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = Math.Round(s.Car.PartsCars.Sum(pc => pc.Part.Price * (1 - (s.Discount / 100))), 4)
                })
                .ToArray();


            XmlSerializer xmlSerializer =
            new XmlSerializer(typeof(ExportAllSalesDto[]), new XmlRootAttribute("sales"));

            var nsXml = new XmlSerializerNamespaces();
            nsXml.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, sales, nsXml);
            }

            return sb.ToString().TrimEnd();

        }
    }
}
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

            Console.WriteLine(GetTotalSalesByCustomer(context));                           // P18

        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }


        public static string GetTotalSalesByCustomer(CarDealerContext context)         // P18
        {
            var mapper = GetMapper();

            var customerSales = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(s => s.Car.PartsCars)
                .ThenInclude(pc => pc.Part)
                .Where(c => c.Sales.Any())
                .AsEnumerable()
                .Select(c => new ExportSalesByCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.SelectMany(s => s.Car.PartsCars)
                                        .Sum(pc => Math.Round(c.IsYoungDriver ?
                                             pc.Part.Price * 0.95m :
                                             pc.Part.Price, 2))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer =
           new XmlSerializer(typeof(ExportSalesByCustomerDto[]), new XmlRootAttribute("customers"));

            var nsXml = new XmlSerializerNamespaces();
            nsXml.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, customerSales, nsXml);
            }

            return sb.ToString().TrimEnd();

        }
    }
}
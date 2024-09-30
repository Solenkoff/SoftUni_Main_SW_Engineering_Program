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

            //var inputSupplierXml = File.ReadAllText("../../../Datasets/suppliers.xml");    // P09
            //Console.WriteLine(ImportSuppliers(context, inputSupplierXml));

            //var inputPartsXml = File.ReadAllText("../../../Datasets/parts.xml");           // P10
            //Console.WriteLine(ImportParts(context, inputPartsXml));

            //var inputCarXml = File.ReadAllText("../../../Datasets/cars.xml");              // P11 
            //Console.WriteLine(ImportCars(context, inputCarXml));

            //var inputCustomersXml = File.ReadAllText("../../../Datasets/customers.xml");   // P12 
            //Console.WriteLine(ImportCustomers(context, inputCustomersXml));

            //var inputSalesXml = File.ReadAllText("../../../Datasets/sales.xml");           // P13
            //Console.WriteLine(ImportSales(context, inputSalesXml));

            //Console.WriteLine(GetCarsWithDistance(context));                               // P14

            //Console.WriteLine(GetCarsFromMakeBmw(context));                                // P15

            //Console.WriteLine(GetLocalSuppliers(context));                                 // P16

            //Console.WriteLine(GetCarsWithTheirListOfParts(context));                       // P17

            //Console.WriteLine(GetTotalSalesByCustomer(context));                           // P18

            //Console.WriteLine(GetSalesWithAppliedDiscount(context));                       // P19

        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }


        public static string ImportSuppliers(CarDealerContext context, string inputXml)     // P09
        {
            // 1.  Create Xml Serializer
            XmlSerializer xmlSerializer = 
                new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            // 2.  Deserialization
            using var reader = new StringReader(inputXml);
            ImportSupplierDto[] importSupplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);

            // 3.  Mapping from ImportSupplierDto => Supplier  with  AutoMapper
            var mapper = GetMapper();
            Supplier[] suppliers = mapper.Map<Supplier[]>(importSupplierDtos);

            // 4.  Add to EF Context
            context.AddRange(suppliers);

            // 5.  Commit changes to DB
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
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
                .Where(p =>existingSupplierIDs.Contains(p.SupplierId));

            var mapper = GetMapper();
            Part[] parts = mapper.Map<Part[]>(partsWithExistingSupplier);

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {partsWithExistingSupplier.Count()}";

        }

        public static string ImportCars(CarDealerContext context, string inputXml)       // P11
        {
            XmlSerializer xmlSerializer =
               new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            using var reader = new StringReader(inputXml);
            ImportCarDto[] importCarDtos = (ImportCarDto[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();

            List<Car> cars = new List<Car>();

            foreach (var carDto in importCarDtos)
            {
                Car car = mapper.Map<Car>(carDto);

                int[] carPartIds = carDto.PartIds
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                var carParts = new List<PartCar>();

                foreach (var id in carPartIds)
                {
                    carParts.Add(new PartCar
                    {
                        Car = car,
                        PartId = id
                    });
                }

                car.PartsCars = carParts;
                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";

        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)     // 12
        {
            XmlSerializer xmlSerializer =
              new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            using var reader = new StringReader(inputXml);
            ImportCustomerDto[] importCustomerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            Customer[] customers = mapper.Map<Customer[]>(importCustomerDtos);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";

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

            using(StringWriter sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, cars, nsXml);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)          // P15
        {
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

            return SerializeToXml<ExportBMWCarDto[]>(carsBMW, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)               // P16
        {
            var nonImporters = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return SerializeToXml<ExportLocalSuppliersDto[]>(nonImporters, "suppliers");

        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)     // P17
        {
            
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

            return SerializeToXml<ExportAllCarsWithPartsDto[]>(allCarsWithParts, "cars");

        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)         // P18
        {
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

            return SerializeToXml<ExportSalesByCustomerDto[]>(customerSales, "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)       // P19
        {
           
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

            return SerializeToXml<ExportAllSalesDto[]>(sales, "sales");

        }



        private static string SerializeToXml<T>(T dto, string xmlRootAttribute)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb, CultureInfo.InvariantCulture))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(stringWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return sb.ToString();
        }

    }
}
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

            //string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");   // P09
            //Console.WriteLine(ImportSuppliers(context, suppliersJson));

            //string partsJson = File.ReadAllText("../../../Datasets/parts.json");           // P10
            //Console.WriteLine(ImportParts(context, partsJson));

            //string carsJson = File.ReadAllText("../../../Datasets/cars.json");             // P11
            //Console.WriteLine(ImportCars(context, carsJson));

            //string customersJson = File.ReadAllText("../../../Datasets/customers.json");   // P12
            //Console.WriteLine(ImportCustomers(context, customersJson));

            //string salesJson = File.ReadAllText("../../../Datasets/sales.json");           // P13
            //Console.WriteLine(ImportSales(context, salesJson));

            //Console.WriteLine(GetOrderedCustomers(context));                               // P14

            //Console.WriteLine(GetCarsFromMakeToyota(context));                             // P15

            //Console.WriteLine(GetLocalSuppliers(context));                                 // P16

            //Console.WriteLine(GetCarsWithTheirListOfParts(context));                       // P17

            //Console.WriteLine(GetTotalSalesByCustomer(context));                           // P18

            //Console.WriteLine(GetSalesWithAppliedDiscount(context));                       // P19
        }


        public static string ImportSuppliers(CarDealerContext context, string inputJson)   // P09
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            SupplierDTO[] supplierDTOs = JsonConvert.DeserializeObject<SupplierDTO[]>(inputJson);
            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDTOs);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
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

        public static string ImportCars(CarDealerContext context, string inputJson)    // P11
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            CarDTO[] carDTOs = JsonConvert.DeserializeObject<CarDTO[]>(inputJson);

            ICollection<Car> cars = new HashSet<Car>();
            ICollection<PartCar> partCars = new HashSet<PartCar>();

            foreach (var carDTO in carDTOs)
            {
                Car currCar = mapper.Map<Car>(carDTO);

                foreach (var partId in carDTO.PartsId.Distinct())
                {
                    var partCar = new PartCar
                    {
                        PartId = partId,
                        Car = currCar
                    };

                    partCars.Add(partCar);
                }

                cars.Add(currCar);
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)   // P12
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            CustomerDTO[] customerDTOs = JsonConvert.DeserializeObject<CustomerDTO[]>(inputJson);
            Customer[] customers = mapper.Map<Customer[]>(customerDTOs);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";

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

        public static string GetOrderedCustomers(CarDealerContext context)       // P14
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToArray();

            var customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)      // P15
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            var toyotasJson = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            return toyotasJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)         // P16
        {
            var nonImporters = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var nonImportersJson = JsonConvert.SerializeObject(nonImporters, Formatting.Indented);

            return nonImportersJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)     // P17
        {
            var cars = context.Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance,
                    Parts = c.PartsCars
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString("f2")
                        })
                        .ToArray()
                })
                .ToArray();

            var formattedCars = cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.Parts
                })
                .ToArray();

            var carsJson = JsonConvert.SerializeObject(formattedCars, Formatting.Indented);

            return carsJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)        // P18
        {
            var customerData = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.SelectMany(s => s.Car.PartsCars).Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            var customerDataJson = JsonConvert.SerializeObject(customerData, Formatting.Indented);

            return customerDataJson;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)     // P19
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("f2"),
                    price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartsCars
                            .Sum(pc => pc.Part.Price) * (100 - s.Discount) / 100).ToString("f2")
                })
                .Take(10)
                .ToArray();

            var salesJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesJson;
        }
    }
}
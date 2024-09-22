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

            var inputCarXml = File.ReadAllText("../../../Datasets/cars.xml");              // P11 
            Console.WriteLine(ImportCars(context, inputCarXml));

        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }


        public static string ImportCars(CarDealerContext context, string inputXml)         // P11
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
    }
}